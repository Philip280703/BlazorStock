using BlazorStock.Server.DataAccess;
using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories
{
    public class PortfolioRepositorySQL : IPortfolioRepository
    {
        private readonly MyDbContext db = new MyDbContext();

        public PortfolioRepositorySQL() { }

        // Get all portfolios
        public List<Portfolio> GetAll()
        {
            var result = db.PortfolioEF.OrderBy(p => p.Id).ToList();
            return result;
        }

        // Get a single portfolio by ID
        public Portfolio GetById(int id)
        {
            var result = db.PortfolioEF.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                return result;
            }
            return new Portfolio { Id = -1 }; // Return a placeholder if not found
        }

        // Add a new portfolio
        public void AddPortfolio(Portfolio portfolio)
        {
            db.PortfolioEF.Add(portfolio);
            db.SaveChanges();
            Console.WriteLine("Added Portfolio to the database.");
        }

        // Update an existing portfolio
        public bool UpdatePortfolio(Portfolio portfolio)
        {
            var currentPortfolio = db.PortfolioEF.SingleOrDefault(p => p.Id == portfolio.Id);
            if (currentPortfolio == null)
            {
                return false;
            }

            // Update the fields
            currentPortfolio.Name = portfolio.Name;
            currentPortfolio.UserID = portfolio.UserID;
            currentPortfolio.TotalValue = portfolio.TotalValue;
            currentPortfolio.Holdings = portfolio.Holdings;

            db.SaveChanges();
            return true;
        }

        // Delete a portfolio
        public bool DeletePortfolio(int id)
        {
            var portfolioToDelete = db.PortfolioEF.SingleOrDefault(p => p.Id == id);
            if (portfolioToDelete == null)
            {
                return false;
            }

            db.PortfolioEF.Remove(portfolioToDelete);
            db.SaveChanges();
            return true;
        }
    }
}
