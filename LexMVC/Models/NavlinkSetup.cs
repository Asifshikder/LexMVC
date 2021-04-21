using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class NavlinkSetup
    {
        [Key]
        public int SetupId { get; set; }
        public int? BasicProductId { get; set; }
        public int? AdvanceProductId { get; set; }
        public int? UltimateProductId { get; set; }
    }
}
