using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Server.Repositories;
using BlazorStock.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorStock.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserRepository Repository = new UserRepositorySQL();

        public UserController(IUserRepository repository)
        {
            if (Repository == null && repository != null)
            {
                Repository = repository;
                Console.WriteLine("Repo initialized");
            }
        }

        [HttpGet]
        public IEnumerable<User> GetallUsers()
        {
            Console.WriteLine("HttpGet called..");
            return Repository.GetAllUsers();
        }

        [HttpGet("{id:int}")]
        public User GetUser(int id)
        {
            Console.WriteLine("Get user called");
            var result = Repository.GetById(id);
            return result;
        }

        [HttpPost]
        public void AddUser(User user)
        {
            Console.WriteLine("Addportfolio Post called");
            Repository.AddUser(user);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            Console.WriteLine("Update portfolio Put called");
            Repository.UpdateUser(user);
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            Console.WriteLine("httpDelete called");
            Repository.DeleteUser(id);
        }
    }
}
