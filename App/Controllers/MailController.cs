using Microsoft.AspNetCore.Mvc;
using SendingEmail.App.Services;

namespace SendingMail.App.Controllers;

public class MailRequest
{
    public string Email { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

[ApiController]
[Route("api/mails")]
public class MailController: ControllerBase
{
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost()]
    public IActionResult SendMail([FromBody] MailRequest mailRequest)
    { 
        _mailService.SendMail(new Mailer() {
            Content = mailRequest.Content,
            Subject = "Test avec un service",
            To = mailRequest.Email
        });

        return Ok(new
        {
            message = "Email sent"
        });
    }
}