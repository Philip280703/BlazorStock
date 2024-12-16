using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Server.Repositories;
using BlazorStock.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorStock.Server.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TradeTransactionController
    {
        private readonly ITradeTransactionRepository Repository = new TradeTransactionRepositorySQL();

        public TradeTransactionController(ITradeTransactionRepository repository)
        {
            if (Repository == null && repository != null)
            {
                Repository = repository;
                Console.WriteLine("Repo initialized");
            }
        }

        [HttpGet]
        public IEnumerable<TradeTransaction> GetAlltransaction()
        {
            Console.WriteLine("HttpGet called..");
            return Repository.GetAllTransactions();
        }

        [HttpGet("{id:int}")]
        public TradeTransaction GetTransaction(int id)
        {
            Console.WriteLine("Get holding called");
            var result = Repository.GetTransactionById(id);
            return result;
        }

        [HttpPost]
        public void AddTransaction(TradeTransaction tradeTransaction)
        {
            Console.WriteLine("AddHolding Post called");
            Repository.AddTransaction(tradeTransaction);
        }

        [HttpPut]
        public void UpdateTransaction(TradeTransaction transaction)
        {
            Console.WriteLine("Update Holding Put called");
            Repository.UpdateTransaction(transaction);
        }

        [HttpDelete]
        public void DeleteTransaction(int id)
        {
            Console.WriteLine("httpDelete called");
            Repository.DeleteTransaction(id);
        }
    }
}
