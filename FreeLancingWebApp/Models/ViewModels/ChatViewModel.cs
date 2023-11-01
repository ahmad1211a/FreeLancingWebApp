namespace FreeLancingWebApp.Models.ViewModels
{
    public class ChatViewModel
    {
        public string UserId { get; set; } // The user's ID
        public string UserName { get; set; } // The user's username
        public List<ChatMessageViewModel> ChatMessages { get; set; } // List of chat messages
        public string Message { get; set; } // The message being sent

    }
}
