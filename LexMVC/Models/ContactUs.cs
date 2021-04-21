using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LexMVC.Models
{
    public class ContactUs
    {
        [Key]

        public int ContactUsId { get; set; }
        public string MapUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
