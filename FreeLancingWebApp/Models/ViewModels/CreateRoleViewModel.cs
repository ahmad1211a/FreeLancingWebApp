using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace FreeLancingWebApp.Models.ViewModels 
{
    public class CreateRoleViewModel
    
       
        {
        //requaired
         public string? Rolename { get; set; }
        [Key]
        public int RoleId { get; set; }
    }
    
}
