using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeLancingWebApp.Models.ViewModels
{
    public class profileViewModels
    {
        [Key]
        public int Profileid { get; set; }

     
        public string? Email { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string? SelfDescription { get; set; }
        public bool Remotly { get; set; }
        public string? Img { get; set; }

        public string Location { get; set; }
        public string Name { get; set; }
        public string? Expertise { get; set;}


    }
}
