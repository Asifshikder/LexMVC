using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexMVC.Models
{
    public class GlobSetVM
    {
        [Key]

        public int? BasicProductId { get; set; }
        public int? AdvanceProductId { get; set; }
        public int? UltimateProductId { get; set; }
        public int SettingsId { get; set; }
        public bool IsBlogEnabled { get; set; } = false;
        public bool UseSmallFooter { get; set; } = false;
    }
}
