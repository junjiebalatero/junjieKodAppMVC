using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodApp.Models
{
    public class Kod
    {
        [Key]
        public int videokeId { get; set; }   
        
        [Required(ErrorMessage = "A number is required")]
        [DisplayName("Song Number")]
        public int songNumber { get; set; }  
        
        [Required]
        public string title { get; set; }
        
        public string artist { get; set; }
       
        public string description { get; set; }
    }
}
