using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LexMVC.Models
{
    public class Category
    {
        [Key]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
