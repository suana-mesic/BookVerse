using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Captcha.Commands.Verify;

// Thin wrapper that delegates to ICaptchaVerifier so the standalone /Captcha/verify endpoint
// uses the same logic as the auth handlers (Login, Register, ForgotPassword).
public sealed class VerifyCaptchaCommandHandler(ICaptchaVerifier captchaVerifier)
    : IRequestHandler<VerifyCaptchaCommand>
{
    public Task Handle(VerifyCaptchaCommand request, CancellationToken ct)
        => captchaVerifier.VerifyAsync(request.Token, request.Answer, ct);
}
