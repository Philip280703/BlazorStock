using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Server.Repositories;
using BlazorStock.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorStock.Server.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioController
    {
        private readonly IPortfolioRepository Repository = new PortfolioRepositorySQL();

        public PortfolioController(IPortfolioRepository repository)
        {
            if (Repository == null && repository != null)
            {
                Repository = repository;
                Console.WriteLine("Repo initialized");
            }
        }

        [HttpGet]
        public IEnumerable<Portfolio> GetAllPortfolios()
        {
            Console.WriteLine("HttpGet called..");
            return Repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public Portfolio GetPortfolio(int id)
        {
            Console.WriteLine("Get portfolio called");
            var result = Repository.GetById(id);
            return result;
        }

        [HttpPost]
        public void AddHolding(Portfolio portfolio)
        {
            Console.WriteLine("Addportfolio Post called");
            Repository.AddPortfolio(portfolio);
        }

        [HttpPut]
        public void UpdatePortfolio(Portfolio portfolio)
        {
            Console.WriteLine("Update portfolio Put called");
            Repository.UpdatePortfolio(portfolio);
        }

        [HttpDelete]
        public void DeletePortfolio(int id)
        {
            Console.WriteLine("httpDelete called");
            Repository.DeletePortfolio(id);
        }
    }
}
