using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Models
{
    public class EmailSetting
    {
        [Key]
        public int EmailSettingsId { get; set; }
        public string SenderEmail { get; set; }
        public string HostName { get; set; }
        public string PortName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
