using FreeLancingWebApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeLancingWebApp.Models.ViewModels
{
    public class RegisterViewModel : CommonProp

    {
        [Key] 
        public int ID { get; set; }
        [Required(ErrorMessage="Pease enter Email")]
        [MaxLength(40,ErrorMessage="Max 40 chars")]
        [EmailAddress(ErrorMessage ="Example@gmail.com")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "please enter a password")]
        [DataType(DataType.Password)]
       
        public string? Password { get; set; }
        [Required(ErrorMessage ="please confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="miss match")]
        public string? ConfirmPassword { get; set; }
        public string? SelfDescription { get; set; }
        public string? Expertise { get; set; }

        public bool Remotly { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string? Img { get; set; }
        public string Location { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

    }
}
