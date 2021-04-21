using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LexMVC.Areas.Admin.Models
{
    public class AboutUsModel
    {
        public int AboutUsId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        [DataType(DataType.Upload)]
        public string ImageFile { get; set; }
    }
}
