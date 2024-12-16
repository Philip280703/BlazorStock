using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStock.Shared.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; } // Primary Key

        [Required]
        [MaxLength(10)]
        public string TickerSymbol { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }

        [MaxLength(50)]
        public string Market { get; set; }

        [MaxLength(50)]
        public string Sector { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DividendYield { get; set; }
    }
}
