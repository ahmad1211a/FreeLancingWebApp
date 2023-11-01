using System.ComponentModel.DataAnnotations;

namespace FreeLancingWebApp.Models.ViewModels
{
    public class EditRoleViewModel
    {
        [Key]

        public string? RoleId { get; set; }

        public EditRoleViewModel()
        {

        Users = new List<string>();
        }
        [Required(ErrorMessage="Enter Role Name")]
        [MinLength(3,ErrorMessage ="min 3 char")]
        [MaxLength(25,ErrorMessage ="MAx 25 char")]
        public string? RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}

