using System.Security;
namespace YuriyShop.Domain.Models.Mail
{
    public interface IEmailSender
    {
        public void Authenticate(string username, string password, string server,  int port);
        public void SendMail(string sendTo,string sendFrom, string subject,string body);
        public void Disconnect();

    }
}
