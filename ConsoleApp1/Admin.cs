using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Admin
    {
        [Key]
        [EmailAddress]
        [Required]
        public string Email_Id { get; set; }
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }
    }
}