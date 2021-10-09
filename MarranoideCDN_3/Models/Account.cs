using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Models
{
    public class Account
    {
        [Key] public string IDAccount { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string PasswordHash { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
    }
}
