using System.Net;
using System.Net.Mail;
using ServiceStack;
using meetroomreservation.CoreServices.Interfaces;

namespace meetroomreservation.Business.CoreServices
{
    public class EmailManagementService : IEmailManagementService
    {
        private string _emailSender;
        private string _password;

        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;



        public EmailManagementService(IConfiguration configuration, ILoggerService loggerService)
        {
            _configuration = configuration;
            _loggerService = loggerService;
            _emailSender = configuration.GetValue<string>("EmailSettings:EmailSender");
            _password = configuration.GetValue<string>("EmailSettings:EmailPassword");
        }

        public bool SendEmail(string receiverEmail, string html, string subject)
        {
            if (_emailSender.IsNullOrEmpty())
            {
                _loggerService.LogInfo("The sender email must to be configured.");
                return false;
            }
            if (html.IsNullOrEmpty())
            {
                _loggerService.LogInfo("The html must to be configured.");
                return false;
            }
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress($@"{_emailSender}");
                message.To.Add(new MailAddress($@"{receiverEmail}"));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = html;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential($@"{_emailSender}", $@"{_password}");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception exception)
            {
                _loggerService.LogErrorServicesBackground(exception);
                return false;
            }
        }
    }
}