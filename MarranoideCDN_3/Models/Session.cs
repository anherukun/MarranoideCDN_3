using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Models
{
    public class Session
    {
        [Key] public string IDSession { get; set; }
        [Required] public string IDAccount { get; set; }
        public string SessionToken { get; set; }
        [Required] public DateTime LastLogin { get; set; }
    }
}
