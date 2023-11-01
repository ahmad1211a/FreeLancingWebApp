namespace FreeLancingWebApp.Models.ViewModels
{
    public class ChatMessageViewModel
    {
        public string SenderId { get; set; } // The user ID of the sender
        public string ReceiverId { get; set; } // The user ID of the receiver
        public string Content { get; set; } // The content of the message
        public DateTime Timestamp { get; set; } // The timestamp of the message

    }
}
