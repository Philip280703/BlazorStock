using BlazorStock.Server.DataAccess;
using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories
{
    public class HoldingRepositorySQL : IHoldingRepository
    {
        private readonly MyDbContext db = new MyDbContext();

        public HoldingRepositorySQL() { }

        // Get all holdings
        public List<Holding> GetAllHoldings()
        {
            var result = db.HoldingEF.OrderBy(h => h.HoldingID).ToList();
            return result;
        }

        // Get a single holding by ID
        public Holding GetHoldingById(int holdingId)
        {
            var result = db.HoldingEF.SingleOrDefault(h => h.HoldingID == holdingId);
            if (result != null)
            {
                return result;
            }
            return new Holding { HoldingID = -1 }; // Return a placeholder if not found
        }

        // Add a new holding
        public void AddHolding(Holding holding)
        {
            db.HoldingEF.Add(holding);
            db.SaveChanges();
            Console.WriteLine("Added Holding to the database.");
        }

        // Update an existing holding
        public bool UpgradeHolding(Holding holding)
        {
            var currentHolding = db.HoldingEF.SingleOrDefault(h => h.HoldingID == holding.HoldingID);
            if (currentHolding == null)
            {
                return false;
            }

            // Update the fields
            currentHolding.PortfolioID = holding.PortfolioID;
            currentHolding.StockID = holding.StockID;
            currentHolding.Shares = holding.Shares;
            currentHolding.PurchasePrice = holding.PurchasePrice;

            db.SaveChanges();
            return true;
        }

        // Delete a holding
        public bool DeleteHolding(int holdingId)
        {
            var holdingToDelete = db.HoldingEF.SingleOrDefault(h => h.HoldingID == holdingId);
            if (holdingToDelete == null)
            {
                return false;
            }

            db.HoldingEF.Remove(holdingToDelete);
            db.SaveChanges();
            return true;
        }
    }
}
