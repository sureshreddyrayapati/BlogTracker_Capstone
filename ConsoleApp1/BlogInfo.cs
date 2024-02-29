using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BlogInfo
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(50)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        public string BlogUlrb { get; set; }
        [EmailAddress]
        [Required]
        
        public string EmpEmailId { get; set; }
        

    }
}