using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{


    public class SearchVM
    {
        public List<Product> Products { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }
}
