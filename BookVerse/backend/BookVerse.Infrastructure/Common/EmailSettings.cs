using MailKit.Security;

namespace BookVerse.Infrastructure.Common
{
    public class EmailSettings
    {
        public const string SectionName = "EmailSettings";
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }

        // Real SMTP security mode (None, Auto, SslOnConnect, StartTls, StartTlsWhenAvailable).
        // Before, the code hardcoded StartTls and the old "EnableSsl" flag from appsettings
        // was read but never used, so changing it in config did nothing. Now this property
        // is bound from appsettings and actually passed to SmtpClient.ConnectAsync.
        public SecureSocketOptions SecureSocketOptions { get; set; } = SecureSocketOptions.StartTls;
    }
}
