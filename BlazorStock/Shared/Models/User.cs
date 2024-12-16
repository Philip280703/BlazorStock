using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStock.Shared.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; } // Primary Key

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        // Navigation Property
        public ICollection<Portfolio> ?Portfolios { get; set; } = new List<Portfolio>();
    }
}
