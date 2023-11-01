using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeLancingWebApp.Models.SharedProp;

namespace FreeLancingWebApp.Models
{
    public class Service : CommonProp
    {


        [Key]
         
        public int ServiceId { get; set; }
        public string? Category { get; set; } 
        public string? ServiceDesc { get; set; }
        public string? ServiceImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
      
       

    }
}
