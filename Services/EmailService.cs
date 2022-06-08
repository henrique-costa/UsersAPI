using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string[] recipient, string subject, int userId, string activationCode)
        {
            MailMessage message = new MailMessage(recipient, subject, userId, activationCode);

            var mailMessage = CreateMailBody(message);
            Send(mailMessage);
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    //client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    //    _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.Connect("smtp.gmail.com", 465, true);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");



                    //client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"), _configuration.GetValue<string>("EmailSettings:Password"));
                  
                    client.Authenticate("hvc19911991@gmail.com", "ljezyetpumzkzmvk");
                    client.Send(mailMessage);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateMailBody(MailMessage message)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mailMessage.To.AddRange(message.Recipient);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) {
                Text = message.Content
            };

            return mailMessage;
        }
    }
}
