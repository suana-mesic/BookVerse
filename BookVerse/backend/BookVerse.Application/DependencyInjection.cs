using BookVerse.Application.Common.Behaviors;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Common.Services;
using BookVerse.Application.Modules.Captcha;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookVerse.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // MediatR only from the Application layer
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        // FluentValidation from the Application layer
        services.AddValidatorsFromAssembly(assembly);

        // Pipeline behaviors (e.g. ValidationBehavior)
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // TimeProvider — used by handlers and services for testable "now".
        services.AddSingleton(TimeProvider.System);

        // Captcha verification shared between the standalone endpoint and auth handlers.
        // Singleton because it's stateless (just HMAC + parsing).
        services.AddSingleton<ICaptchaVerifier, CaptchaVerifier>();

        // Domain services extracted from the order/payment handlers so each handler
        // only orchestrates and every rule can be unit tested in isolation.
        // Scoped because most of them depend on IAppDbContext (scoped EF DbContext).
        services.AddSingleton<ICheckoutPricingService, CheckoutPricingService>();
        services.AddScoped<ICouponValidationService, CouponValidationService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddSingleton<IOrderStateMachine, OrderStateMachine>();

        return services;
    }
}
