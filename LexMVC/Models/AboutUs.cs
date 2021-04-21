using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
