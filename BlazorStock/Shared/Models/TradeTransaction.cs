using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStock.Shared.Models
{
    public class TradeTransaction
    {
        [Key]
        public int TransactionID { get; set; } // Primary Key

        [ForeignKey("Holding")]
        public int HoldingID { get; set; } // Foreign Key

        [Required]
        [MaxLength(10)]
        public string Type { get; set; } // "Buy" or "Sell"

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shares { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerShare { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fees { get; set; }

        // Navigation Property
        public Holding ?Holding { get; set; }
    }
}
