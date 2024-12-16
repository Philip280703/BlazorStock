using BlazorStock.Server.Repositories;
using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorStock.Server.Controllers
{
    [ApiController]
    [Route("api/holding")]
    public class HoldingController
    {
        private readonly IHoldingRepository Repository = new HoldingRepositorySQL();

        public HoldingController(IHoldingRepository repository)
        {
            if(Repository == null && repository != null)
            {
                Repository = repository;
                Console.WriteLine("Repo initialized");
            }
        }

        [HttpGet]
        public IEnumerable<Holding> GetAllHoldings()
        {
            Console.WriteLine("HttpGet called..");
            return Repository.GetAllHoldings();
        }

        [HttpGet("{id:int}")]
        public Holding GetHolding(int id) 
        {
            Console.WriteLine("Get holding called");
            var result = Repository.GetHoldingById(id);
            return result;
        }

        [HttpPost]
        public void AddHolding(Holding holding)
        {
            Console.WriteLine("AddHolding Post called");
            Repository.AddHolding(holding);
        }

        [HttpPut]
        public void UpdateHolding(Holding holding)
        {
            Console.WriteLine("Update Holding Put called");
            Repository.UpgradeHolding(holding);
        }

        [HttpDelete]
        public void DeleteHolding(int id) 
        {
            Console.WriteLine("httpDelete called"); 
            Repository.DeleteHolding(id);
        }


    }
}
