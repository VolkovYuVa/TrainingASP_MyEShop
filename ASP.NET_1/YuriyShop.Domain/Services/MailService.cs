using MimeKit.IO.Filters;
using YuriyShop.Domain.Models.Mail;

namespace YuriyShop.Domain.Services
{
    class MailService 
    {
        private IEmailSender _emailSender { get; set; }
        private string _userName {  get; set; }
        private string _password { get; set; }
        private string _server {  get; set; }
        private int _port { get; set; }
        public MailService(IEmailSender emailSender)
        {
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            GetLoginData();
            Authenticate(_userName, _password, _server, _port);
        }

        private void GetLoginData()
        {
            _userName = Environment.GetEnvironmentVariable("YuriyShop_SMTPLogin");
            _password = Environment.GetEnvironmentVariable("YuriyShop_SMTPPassword");
            _server = Environment.GetEnvironmentVariable("YuriyShop_SMTPServer");
            _port = Int32.Parse( Environment.GetEnvironmentVariable("YuriyShop_SMTPPort"));
        }

        public void Authenticate(string username, string password, string server, int port)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(server))
            { 
                throw new ArgumentNullException(nameof(username) + nameof(password) + nameof(server));
            }

            _emailSender.Authenticate(username, password, server, port);
        }

        public void SendMail(string sendTo, string sendFrom, string subject, string body)
        {
            if(sendTo == null) 
            {
                return;
            }
            _emailSender.SendMail(sendTo, sendFrom, subject, body);
        }

        public void Disconnect()
        { 
            _emailSender?.Disconnect();
        }


    }
}
