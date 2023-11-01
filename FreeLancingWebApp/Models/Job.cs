using FreeLancingWebApp.Models.SharedProp;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeLancingWebApp.Models

{
    public class Job :CommonProp
    {
        [Key]
        public int JobId { get; set; }
        public string? JobName { get; set; } 
        public string? JobDescription { get; set; }
        public string?  UEmail { get; set; }
        public int? price { get; set; }
        public string? UName { get; set; }
        public string? AdditinalInformation { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string? Img { get; set; }
        [ForeignKey("ServiceId")]

        public int? ServiceId { get; set; }

        public Service? Service { get; set; }


    }
}
