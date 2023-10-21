using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace SendingEmail.App.Services;

public class Mailer
{
    public string Subject { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public MimeMessage IniitializeEmail()
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("no-reply@ivoiredevacademy.com"));
        email.To.Add(MailboxAddress.Parse(To));
        email.Subject = Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = Content };

        return email;
    }
}


public class MailService : IMailService
{

    public void SendMail(Mailer mailer)
    {
        var email = mailer.IniitializeEmail();

        using var smtpClient = new SmtpClient();
        smtpClient.Connect("localhost", 1025, MailKit.Security.SecureSocketOptions.None);
        smtpClient.Send(email);
        smtpClient.Disconnect(true);
    }

}