
namespace SendingEmail.App.Services
{

    public interface IMailService
    {
        public void SendMail(Mailer mailer);
    }
}