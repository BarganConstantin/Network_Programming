using MailKit.Net.Imap;
using MailKit;
using MailKit.Net.Pop3;
using MailKit.Search;
using MailKit.Security;
using System;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.GetEnvironmentVariable("mail_username");
            string password = Environment.GetEnvironmentVariable("mail_password");

            // ------------------------------------------------------------------------------------------

            // list mails through pop3
            //using (var client = new Pop3Client())
            //{
            //    client.Connect("pop.mail.ru", 995, true);
            //    client.Authenticate(username, password);
            //    Console.WriteLine("Available Messages: " + client.Count);

            //    for (int i = 0; i < client.Count; i++)
            //    {
            //        var message = client.GetMessage(i);
            //        Console.WriteLine("Subject: {0}", message.Subject);
            //        Console.WriteLine("From: {0}", message.From);
            //        Console.WriteLine();
            //    }

            //    client.Disconnect(true);
            //}

            // ------------------------------------------------------------------------------------------

            // list mails through imap
            //using (var client = new ImapClient())
            //{
            //    client.Connect("imap.mail.ru", 993, true);

            //    client.Authenticate(username, password);

            //    // The Inbox folder is always available on all IMAP servers...
            //    var inbox = client.Inbox;
            //    inbox.Open(FolderAccess.ReadOnly);

            //    Console.WriteLine("Total messages: {0}", inbox.Count);
            //    Console.WriteLine("Recent messages: {0}", inbox.Recent);

            //    for (int i = 0; i < inbox.Count; i++)
            //    {
            //        var message = inbox.GetMessage(i);
            //        Console.WriteLine("Subject: {0}", message.Subject);
            //    }

            //    client.Disconnect(true);

            //}

            // ------------------------------------------------------------------------------------------

            //creating a simple message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MailClientApp", username));
            message.To.Add(new MailboxAddress("Alice", "constantin.bargan@isa.utm.md"));
            message.Subject = "How you doing?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Alice,

                    What are you up to this weekend? Monica is throwing one of her parties on
                    Saturday and I was hoping you could make it.

                    Will you be my +1?

                    -- Joey
                    "
            };

            //send simple message
            
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);

                client.Authenticate(username, password);

                client.Send(message);

                client.Disconnect(true);
            }
            
        }
    }
}
