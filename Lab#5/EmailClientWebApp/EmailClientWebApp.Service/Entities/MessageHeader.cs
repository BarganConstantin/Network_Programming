using System;

namespace EmailClientWebApp.Services.Entities
{
    public class MessageHeader
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public bool IsRead { get; set; }
        public bool HasAttachments { get; set; }
    }
}
