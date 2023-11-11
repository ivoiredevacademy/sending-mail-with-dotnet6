using Microsoft.AspNetCore.Mvc;
using SendingEmail.App.Services;

namespace SendingMail.App.Controllers;

public class MailDto
{
    public string Email { get; init;  } = string.Empty;
    public string Content { get; init; } = string.Empty;
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
    public IActionResult SendMail([FromBody] MailDto mailDto)
    { 
        _mailService.SendMail(new Mailer() {
            Content = mailDto.Content,
            Subject = "Test avec un service",
            To = mailDto.Email
        });

        return Ok(new
        {
            Message = "Email sent"
        });
    }
}