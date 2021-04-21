using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LexMVC.Models
{
    public class BlogPostVM
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public HttpPostedFileBase BlogImageFile { get; set; }
        public string Content { get; set; }
        public DateTime? PostTime { get; set; }
    }
}
