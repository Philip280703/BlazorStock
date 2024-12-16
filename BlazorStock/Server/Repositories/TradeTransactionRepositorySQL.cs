using BlazorStock.Server.DataAccess;
using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories
{
    public class TradeTransactionRepositorySQL : ITradeTransactionRepository
    {
        private readonly MyDbContext db = new MyDbContext();

        public TradeTransactionRepositorySQL() { }

    
        public List<TradeTransaction> GetAllTransactions()
        {
            var result = db.TransactionEF.OrderBy(t => t.TransactionID).ToList();
            return result;
        }

   
        public TradeTransaction GetTransactionById(int transactionId)
        {
            var result = db.TransactionEF.SingleOrDefault(t => t.TransactionID == transactionId);
            if (result != null)
            {
                return result;
            }
            return new TradeTransaction { TransactionID = -1 }; // Return a placeholder if not found
        }

  
        public void AddTransaction(TradeTransaction transaction)
        {
            db.TransactionEF.Add(transaction);
            db.SaveChanges();
            Console.WriteLine("Added Transaction to the database.");
        }

   
        public bool UpdateTransaction(TradeTransaction transaction)
        {
            var currentTransaction = db.TransactionEF.SingleOrDefault(t => t.TransactionID == transaction.TransactionID);
            if (currentTransaction == null)
            {
                return false;
            }


            currentTransaction.Type = transaction.Type;
            currentTransaction.Shares = transaction.Shares;
            currentTransaction.PricePerShare = transaction.PricePerShare;
            currentTransaction.TransactionDate = transaction.TransactionDate;
            currentTransaction.Fees = transaction.Fees;
            currentTransaction.HoldingID = transaction.HoldingID;

            db.SaveChanges();
            return true;
        }


        public bool DeleteTransaction(int transactionId)
        {
            var transactionToDelete = db.TransactionEF.SingleOrDefault(t => t.TransactionID == transactionId);
            if (transactionToDelete == null)
            {
                return false;
            }

            db.TransactionEF.Remove(transactionToDelete);
            db.SaveChanges();
            return true;
        }
    }
}
