using System.Security;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;

namespace YuriyShop.Domain.Models.Mail
{
    public class SMTPEmailSender:IEmailSender
    {
        private SmtpClient SmtpClient { get; set; }

        public void Authenticate(string server, string username, string password, int port = 25)
        {
            SmtpClient.Connect(server, port, SecureSocketOptions.StartTls);
            SmtpClient.Authenticate(username, password);
        }

        public void SendMail(string sendTo, string sendFrom, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(sendFrom));
            email.To.Add(MailboxAddress.Parse(sendTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };
            SmtpClient.Send(email);
        }

        public void Disconnect()
        {
            SmtpClient.Disconnect(true);
        }
    }
}
