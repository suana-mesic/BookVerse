using BookVerse.API;
using BookVerse.API.BackgroundServices;
using BookVerse.API.Hubs;
using BookVerse.API.Middleware;
using BookVerse.Application;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Infrastructure;
using BookVerse.Infrastructure.Common;
using BookVerse.Infrastructure.Translate;
using Microsoft.Extensions.Options;
using Serilog;
using Stripe;
public partial class Program
{
    private static async Task Main(string[] args)
    {
        //
        // 0) Bootstrap logger (very early, no full config yet)
        //
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console() // minimal sink so we see startup errors
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting BookVerse API...");

            //
            // 1) Standard builder (includes appsettings.json, appsettings.{ENV}.json,
            //    environment variables, user-secrets (Dev), and command-line args)
            //
            DotNetEnv.Env.Load();
            var builder = WebApplication.CreateBuilder(args);

            // 2) Promote Serilog to full configuration from builder.Configuration
            //    (reads "Serilog" section from appsettings + ENV overrides)
            //
            builder.Host.UseSerilog((ctx, services, cfg) =>
            {
                cfg.ReadFrom.Configuration(ctx.Configuration)   // Serilog section in appsettings
                   .ReadFrom.Services(services)                 // DI enrichers if any
                   .Enrich.FromLogContext()
                   .Enrich.WithThreadId()
                   .Enrich.WithProcessId()
                   .Enrich.WithMachineName();
            });

            // Optional: remove default providers to have only Serilog
            builder.Logging.ClearProviders();

            // ---------------------------------------------------------
            // 3. Layer registrations
            // ---------------------------------------------------------
            builder.Services
                .AddAPI(builder.Configuration, builder.Environment)
                .AddInfrastructure(builder.Configuration, builder.Environment)
                .AddApplication();

            var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "allowCors", builder =>
                {
                    builder.WithOrigins(allowedOrigins).AllowCredentials().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
            builder.Services.AddSingleton<IStripeSettings>(sp => sp.GetRequiredService<IOptions<StripeSettings>>().Value);

            // Bind the "Payment" section of appsettings.json to PaymentOptions.
            // ValidateDataAnnotations() runs the [Required]/[StringLength] checks from PaymentOptions.cs.
            // ValidateOnStart() forces those checks to run at application startup, so if Currency is
            // missing or wrong length the app fails fast with a clear error instead of breaking later
            // on the first Stripe call.
            builder.Services
                .AddOptions<PaymentOptions>()
                .Bind(builder.Configuration.GetSection("Payment"))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            // Expose the validated options through IPaymentOptions so handlers can inject the
            // interface (lighter dependency) instead of IOptions<PaymentOptions>.
            builder.Services.AddSingleton<IPaymentOptions>(sp => sp.GetRequiredService<IOptions<PaymentOptions>>().Value);

            // AddControllers (with JSON converter and uniform BadRequest behavior) is registered
            // in DependencyInjection.AddAPI - calling it again here would leave a duplicate filter
            // configuration in the DI container.

            builder.Services.AddSignalR();
            builder.Services.AddScoped<IOrderNotificationService, OrderNotificationService>();

            // IMemoryCache is what TranslationService uses to remember already-translated
            // strings between calls. Without this registration TranslationService cannot
            // be constructed (DI would fail at startup).
            builder.Services.AddMemoryCache();

            // 5 seconds is enough for a normal Google reply. Without an explicit timeout
            // HttpClient defaults to 100 seconds, so a hanging Google call could block a
            // listing request that long. Combined with the CancellationToken inside the
            // service, this guarantees a single translation call never hangs forever.
            builder.Services.AddHttpClient<ITranslationService, TranslationService>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(5);
            });

            //Queue is a singleton (single Channel instance shared by all webhook invocations) and the
            //background service drains it for the lifetime of the process.
            builder.Services.AddSingleton<IPaidOrderNotificationQueue, PaidOrderNotificationQueue>();
            builder.Services.AddHostedService<PaidOrderNotificationBackgroundService>();
            builder.Services.AddHostedService<OrderCleanupBackgroundService>();

            var app = builder.Build();

            // ---------------------------------------------------------
            // 4. Middleware pipeline
            // ---------------------------------------------------------
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Global exception handler (IExceptionHandler)
            app.UseExceptionHandler();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseCors("allowCors");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<StaffOrderHub>("/hubs/orders");
            app.MapHub<UserOrderHub>("/hubs/user-orders");


            // Database migrations + seeding
            await app.Services.InitializeDatabaseAsync(app.Environment);

            Log.Information("BookVerse API started successfully.");
            app.Run();
        }
        catch (HostAbortedException)
        {
            // EF Core tools abort the host after obtaining the DbContext.
            // This is not a runtime error – just exit silently.
            Log.Information("Host aborted by EF Core tooling (design-time) - its ok.");
        }
        catch (Exception ex)
        {
            // Any startup failure will be logged here
            Log.Fatal(ex, "BookVerse API terminated unexpectedly.");
        }
        finally
        {
            // Ensure all logs are flushed before the app exits
            Log.CloseAndFlush();
        }
    }
}
