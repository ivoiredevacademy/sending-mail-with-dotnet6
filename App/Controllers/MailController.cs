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
            Template = "mail.template.html",
            TemplateVariables = new Dictionary<string, string>
            {
                { "email", "no-reply@ivoiredevacedemy.com" }
            },
            Subject = "Test avec un template",
            To = mailDto.Email
        });

        return Ok(new
        {
            Message = "Email sent"
        });
    }
}