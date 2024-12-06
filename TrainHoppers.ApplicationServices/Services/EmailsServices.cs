using Microsoft.Extensions.Configuration;
using MimeKit;
using TrainHoppers.Core.Dto;
using MailKit.Net.Smtp;
using TrainHoppers.Core.ServiceInterface;
using Org.BouncyCastle.Utilities.Encoders;
using System.Buffers.Text;

namespace TrainHoppers.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;
        public EmailsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailUserName").Value = "mellkosk12@gmail.com";
            _configuration.GetSection("EmailPassword").Value = "pofu otcf mlgd hesj";

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));


            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };
            // TrainHoppers = pofu otcf mlgd hesj
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
