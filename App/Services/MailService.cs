using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace SendingEmail.App.Services;

public class Mailer
{
    public string Subject { get; init; } = string.Empty;
    public string To { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
}


public class MailService : IMailService
{
    private readonly MailConfig _mailConfig;

    public MailService(IOptions<MailConfig> options)
    {
        _mailConfig = options.Value;
    }
    
    public void SendMail(Mailer mailer)
    {
        var email = InitializeEmail(mailer);

        using var smtpClient = new SmtpClient();
        smtpClient.Connect(_mailConfig.Host, _mailConfig.Port, MailKit.Security.SecureSocketOptions.None);
        smtpClient.Send(email);
        smtpClient.Disconnect(true);
    }
    
    private MimeMessage InitializeEmail(Mailer mailer)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_mailConfig.FromAdress));
        email.To.Add(MailboxAddress.Parse(mailer.To));
        email.Subject = mailer.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = mailer.Content };

        return email;
    }
}