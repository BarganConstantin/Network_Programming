using EmailClientWebApp.Service.Entities;
using EmailClientWebApp.Services.Entities;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClientWebApp.Service
{
    public class ImapServices
    {
        public List<MessageHeader> GetHeaders(string username, string password, int msgNumber)
        {
            var Headers = new List<MessageHeader>();

            // list mails through pop3
            using (var client = new ImapClient())
            {
                client.Connect(Constants.ImapUrl, Constants.ImapPort, true);
                client.Authenticate(username, password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                var total = inbox.Count - 1;

                int from;
                int to;

                if (total < 10)
                {
                    from = total;
                    to = 0;
                }
                else
                {
                    from = total - msgNumber + 10;
                    to = total - msgNumber;
                }

                for (int i = from; i > to; i--)
                {
                    var message = inbox.GetMessage(i);

                    Headers.Add(new MessageHeader
                    {
                        Id = i,
                        Title = message.Subject,
                        Date = message.Date.UtcDateTime,
                        From = message.From.ToString(),
                        HasAttachments = message.Attachments.Count() > 0
                    });
                }

                client.Disconnect(true);
            }
            return Headers;
        }

        public MsgToDisplay GetMessageById(string username, string password, int msgId)
        {
            MsgToDisplay msg = new MsgToDisplay();

            using (var client = new ImapClient())
            {
                client.Connect(Constants.ImapUrl, Constants.ImapPort, true);
                client.Authenticate(username, password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                var message = inbox.GetMessage(msgId);


                msg.Id = msgId;
                msg.Title = message.Subject;
                msg.Date = message.Date.UtcDateTime;
                msg.From = message.From.ToString();

                msg.Body = message.TextBody;

                List<MimeEntity> attachments = new List<MimeEntity>();
                foreach (var attachment in message.Attachments)
                {
                    attachments.Add(attachment);
                }
                msg.Attachments = attachments;

                client.Disconnect(true);
            }

            return msg;
        }

        public FileData GetAttachment(string username, string password, string msgId, string attachId)
        {
            MimeEntity attachment = null;

            using (var client = new ImapClient())
            {
                client.Connect(Constants.ImapUrl, Constants.ImapPort, true);
                client.Authenticate(username, password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                var message = inbox.GetMessage(Int32.Parse(msgId));

                List<MimeEntity> attachments = new List<MimeEntity>();
                foreach (var attach in message.Attachments)
                {
                    if (attach.ContentId == attachId)
                    {
                        attachment = attach;
                        break;
                    }
                }

                client.Disconnect(true);
            }

            // Get the attachment data
            var stream = new MemoryStream();
            if (attachment is MessagePart rfc822)
            {
                rfc822.Message.WriteTo(stream);
            }
            else
            {
                var part = (MimePart)attachment;
                part.Content.DecodeTo(stream);
            }
            var data = stream.ToArray();

            return new FileData(data, attachment.ContentType.MimeType, ((MimePart)attachment).FileName);
        }
    }
}
