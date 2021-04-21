using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class SiteSetting
    {
        [Key]
        public int SettingsId { get; set; }
        public bool IsBlogEnabled { get; set; } = false;
        public bool UseSmallFooter { get; set; } = false;

    }
}
