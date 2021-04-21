using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class Warranty
    {
        [Key]

        public int WarrantyId { get; set; }
        public string FullName  { get; set; }
        public string Email  { get; set; }
        public string OrderCode  { get; set; }
        public bool? IsLikePurchase  { get; set; }
        public DateTime? AvailDate { get; set; }
    }
}
