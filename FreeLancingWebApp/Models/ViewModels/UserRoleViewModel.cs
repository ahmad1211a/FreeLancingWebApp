using System.ComponentModel.DataAnnotations;

namespace FreeLancingWebApp.Models.ViewModels
{
    public class UserRoleViewModel
    {
        [Key]
        public string? UserId { get; set; }  
        public string? UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
