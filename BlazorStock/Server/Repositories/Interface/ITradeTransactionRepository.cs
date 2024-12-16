using BlazorStock.Shared.Models;
using System.Transactions;

namespace BlazorStock.Server.Repositories.Interface
{
    public interface ITradeTransactionRepository
    {
        List<TradeTransaction> GetAllTransactions();
        TradeTransaction GetTransactionById(int transactionId);
        void AddTransaction(TradeTransaction transaction);
        bool UpdateTransaction(TradeTransaction transaction);
        bool DeleteTransaction(int transactionId);
       
    }
}
