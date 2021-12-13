using Integration.Application.Contracts.Infrastructure;
using Integration.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Integration.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey ?? "");
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress ?? "teddy@test.com",
                Name = _emailSettings.FromName ?? "Teddy Test"
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                _logger.LogInformation("Email sent");
                return true;
            }

            _logger.LogInformation("Email sending failed");
            return false;
        }

        public async Task<bool> SendEmailWithAttachment(Email email, Application.Models.FileInfo file)
        {
            var client = new SendGridClient(_emailSettings.ApiKey ?? "SG.b2tbyKXfQ5Gz5ACGHfVDKQ.zzxzQaP_CePrerOf8xqaJD7ByfzKVL0GHCLqL68MLNs");
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress ?? "teddy@celecsys.com",
                Name = _emailSettings.FromName ?? "Teddy Test"
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            var filename = "user." + file.Extension;
            Attachment attachment = new Attachment();
            attachment.Content = file.File;
            attachment.Type = file.Type;
            attachment.Filename = filename;
            attachment.Disposition = "attachment";
            attachment.ContentId = "User Information";

            sendGridMessage.AddAttachment(attachment);

            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                _logger.LogInformation("Email sent");
                return true;
            }

            _logger.LogInformation("Email sending failed");
            return false;
        }

      
    }
}
