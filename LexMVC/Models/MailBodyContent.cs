using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class MailBodyContent
    {
        [Key]
        public int Id { get; set; }
        public string GreetingHeader { get; set; }
        public string MiddleContent { get; set; }
        public string FooterContent { get; set; }
    }
}
