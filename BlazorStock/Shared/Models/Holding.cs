using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStock.Shared.Models
{
    public class Holding
    {
        [Key]
        public int HoldingID { get; set; } // Primary Key

        [ForeignKey("Portfolio")]
        public int PortfolioID { get; set; } // Foreign Key

        [ForeignKey("Stock")]
        public int StockID { get; set; }

        [Required]
        [MaxLength(10)]
        public string TickerSymbol { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shares { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }

        [NotMapped]
        public decimal TotalValue => Shares * CurrentPrice;

        [NotMapped]
        public decimal ProfitLoss => TotalValue - (Shares * PurchasePrice);

        // Navigation Property
        public Portfolio ?Portfolio { get; set; }
        public Stock ?stock { get; set; }
        public List<TradeTransaction> ?Transactions { get; set; } = new List<TradeTransaction>();
    }
}
