using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailClientWebApp.Services.Entities
{
    public class MsgToDisplay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public bool IsRead { get; set; }
        public string Body { get; set; }
        public List<MimeEntity> Attachments { get; set; }
    }
}
