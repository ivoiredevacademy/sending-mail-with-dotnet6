using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace SendingEmail.App.Services;

public class Mailer
{
    public string Subject { get; init; } = string.Empty;
    public string To { get; init; } = string.Empty;
    public string? Content { get; init; } = null!;

    public string? Template { get; init; } = null!;

    public Dictionary<string, string> TemplateVariables = new Dictionary<string, string>();
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
        email.Body = new TextPart(TextFormat.Html) { Text = GetContent(mailer) };

        return email;
    }

    private static string GetContent(Mailer mailer)
    {
        if (mailer.Content is null && mailer.Template is null)
        {
            throw new Exception("Mailer does not have content");
        }
        
        if (mailer.Content is not null)
        {
            return mailer.Content;
        }

        var templateFullPath = Path.Combine("wwwroot/mails", mailer.Template ?? "");
        var streamReader = new StreamReader(templateFullPath);
        var templateContent = streamReader.ReadToEnd();
        streamReader.Close();

        foreach (var entry  in mailer.TemplateVariables)
        {
            templateContent = templateContent.Replace("{" + entry.Key + "}", entry.Value);
        }

        return templateContent;
    }
}