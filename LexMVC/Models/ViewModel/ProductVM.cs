using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LexMVC.Models
{
    public class ProductVM
    {
        [Key]

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CartDescription { get; set; }
        public string Description { get; set; }
        public string OtherDescription { get; set; }
        public string ProfileImage { get; set; }
        public string ProfileImage1 { get; set; }
        public string ProfileImage2 { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Amazonlink { get; set; }

        public bool IsFeature { get; set; }

        public string    FeatureImage1 { get; set; }
        public string    FeatureImage2 { get; set; }
        public string    FeatureImage3 { get; set; }
        public string    FeatureImage4 { get; set; }
        public string    FeatureImage5 { get; set; }
    }
}
