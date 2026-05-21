using BookVerse.Application.Abstractions;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Infrastructure.Common;
using BookVerse.Infrastructure.Database;
using BookVerse.Shared.Constants;
using BookVerse.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookVerse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment env)
    {
        // Typed ConnectionStrings + validation
        services.AddOptions<ConnectionStringsOptions>()
            .Bind(configuration.GetSection(ConnectionStringsOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // DbContext: InMemory for test environments; SQL Server otherwise
        services.AddDbContext<DatabaseContext>((sp, options) =>
        {
            if (env.IsTest())
            {
                options.UseInMemoryDatabase("IntegrationTestsDb");

                // The in-memory provider has no transaction support, but our handlers now
                // call BeginTransactionAsync() (Register, CreateOrder, StripeWebhook). By default
                // EF turns that into an exception in tests. Telling it to IGNORE the warning
                // makes BeginTransactionAsync return a no-op transaction in tests, so the same
                // handler code path runs against InMemory + SqlServer.
                options.ConfigureWarnings(w =>
                    w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));

                return;
            }

            var cs = sp.GetRequiredService<IOptions<ConnectionStringsOptions>>().Value.Main;
            options.UseSqlServer(cs);
        });

        // IAppDbContext mapping
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<DatabaseContext>());

        // Identity hasher
        services.AddScoped<IPasswordHasher<BookVerseUserEntity>, PasswordHasher<BookVerseUserEntity>>();

        // Token service (reads JwtOptions via IOptions<JwtOptions>)
        services.AddTransient<IJwtTokenService, JwtTokenService>();

        // Hashes 2FA codes with HMAC-SHA256 so plaintext codes never sit in the DB.
        services.AddSingleton<ITwoFactorCodeHasher, TwoFactorCodeHasher>();

        // HttpContext accessor + current user
        services.AddHttpContextAccessor();
        services.AddScoped<IAppCurrentUser, AppCurrentUser>();

        // TimeProvider (if used in handlers/services)
        services.AddSingleton<TimeProvider>(TimeProvider.System);

        services.AddOptions<EmailSettings>().Bind(configuration.GetSection(EmailSettings.SectionName));

        // EmailService now only enqueues messages, so it is cheap and can stay transient.
        services.AddTransient<IEmailService, EmailService>();

        // Domain-language notifiers. Handlers depend on these interfaces (ITwoFactorNotifier,
        // IPasswordResetNotifier) rather than IEmailService, so the infrastructure detail
        // (SMTP today, maybe SMS tomorrow) can change without touching the application layer.
        services.AddTransient<ITwoFactorNotifier, EmailTwoFactorNotifier>();
        services.AddTransient<IPasswordResetNotifier, EmailPasswordResetNotifier>();

        // The queue is a singleton because it is one Channel shared by all producers
        // (every request that wants to send an email) and one background consumer.
        services.AddSingleton<IEmailQueue, EmailQueue>();

        // Hosted service that actually does the SMTP work. Registered here so the whole
        // email subsystem is wired up in one place.
        services.AddHostedService<EmailSenderBackgroundService>();

        return services;
    }
}