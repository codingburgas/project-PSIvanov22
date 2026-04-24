using System;

namespace TheMissChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }

        public int? ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }

        public int? UserId { get; set; }
        public User UserObj { get; set; }
    }
}
