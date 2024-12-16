using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories.Interface
{
    public interface IHoldingRepository
    {
        List<Holding> GetAllHoldings();
        Holding GetHoldingById(int holdingId);
        void AddHolding(Holding holding);
        bool UpgradeHolding(Holding holding);
        bool DeleteHolding(int holdingId);
    }
}
