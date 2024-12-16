using Microsoft.EntityFrameworkCore;
using BlazorStock.Shared;
using BlazorStock.Shared.Models;

namespace BlazorStock.Server.DataAccess
{
    public class MyDbContext : DbContext
    {
        // connectionString til den relationelle database EF skal gemme i.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=azureserverphilip.database.windows.net; Database=PortfolioDB; User Id=AzureDatabase; Password=UclBoulevarden!");
        }

        public DbSet<User> UserEF { get; set; }
        public DbSet<TradeTransaction> TransactionEF { get; set; }
        public DbSet<Stock> StockEF { get; set; }
        public DbSet<Portfolio> PortfolioEF { get; set; }
        public DbSet<Holding> HoldingEF { get; set; }

    }
}
