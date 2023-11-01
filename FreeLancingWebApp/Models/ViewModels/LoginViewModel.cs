using System.ComponentModel.DataAnnotations;

namespace FreeLancingWebApp.Models.ViewModels
{
    public class LoginViewModel

    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pease enter Email")]
        [MaxLength(40, ErrorMessage = "Max 40 chars")]
        [EmailAddress(ErrorMessage = "Example@gmail.com")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "please enter a password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
       
        public bool RememberMe { get; set; }
    }
}
