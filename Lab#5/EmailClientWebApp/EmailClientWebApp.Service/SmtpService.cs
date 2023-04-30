using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmailClientWebApp.Service
{
    public class SmtpService
    {
        public void sendNewEmail(string username, string password, string to, string subject, string message, List<IFormFile> attachment)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(username, username));
            msg.To.Add(new MailboxAddress(to, to));
            msg.Subject = subject;

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = message;

            foreach (var file in attachment)
            {
                // Create an attachment from the uploaded file
                var attachmentContent = new MimeContent(file.OpenReadStream(), ContentEncoding.Default);
                var attachments = new MimePart(file.ContentType)
                {
                    Content = attachmentContent,
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    FileName = file.FileName
                };

                // Add the attachment to the message body
                builder.Attachments.Add(attachments);
            }

            msg.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);

                client.Authenticate(username, password);

                client.Send(msg);

                client.Disconnect(true);
            }
        }
    }
}
