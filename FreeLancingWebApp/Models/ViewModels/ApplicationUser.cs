using Microsoft.AspNetCore.Identity;

namespace FreeLancingWebApp.Models.ViewModels
{
    // ApplicationUser.cs
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // ChatMessage.cs
    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
