using System;
using System.Collections.Generic;

namespace TheMissChat.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public List<Message> Messages { get; set; }
    }
}
