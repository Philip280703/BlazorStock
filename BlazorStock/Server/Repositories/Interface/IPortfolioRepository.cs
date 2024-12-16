using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories.Interface
{
    public interface IPortfolioRepository
    {
        List<Portfolio> GetAll();
        Portfolio GetById(int id);
        void AddPortfolio(Portfolio portfolio);
        bool UpdatePortfolio(Portfolio portfolio);
        bool DeletePortfolio(int id);
    }
}
