using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SendingMail.App.Controllers;

public class MailDto
{
    public string Email { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

[ApiController]
[Route("api/mails")]
public class MailController: ControllerBase
{
    [HttpPost()]
    public IActionResult SendMail([FromBody] MailDto mailDto)
    {
        // Definir le mail
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("no-reply@ivoiredevacademy.com"));
        email.To.Add(MailboxAddress.Parse(mailDto.Email));
        email.Subject = "Test Email";
        email.Body = new TextPart(TextFormat.Html) { Text = mailDto.Content };

        // Envoyer le mail
        using var smtpClient = new SmtpClient();
        smtpClient.Connect("localhost", 1025, MailKit.Security.SecureSocketOptions.None);
        //smtpClient.Authenticate("", "");

        smtpClient.Send(email);
        smtpClient.Disconnect(true);

        return Ok(new
        {
            message = "Email sent"
        });
    }
}