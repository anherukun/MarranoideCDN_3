using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Models
{
    public class Account
    {
        [Key] public string IDAccount { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string PasswordHash { get; set; }
        [ForeignKey("UserRol")][Required] public string IDUserRol { get; set; }
        public virtual UserRol UserRol { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
    }

    public class UserRol
    {
        [Key] public string IDUserRol { get; set; }
        [Required] public int UserLevel { get; set; }
        [Required] public string UserRolName { get; set; }
        [Required] public string UserRolPermisions { get; set; }
    }
}
