using BlazorStock.Server.DataAccess;
using BlazorStock.Server.Repositories.Interface;
using BlazorStock.Shared.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BlazorStock.Server.Repositories
{
    public class UserRepositorySQL : IUserRepository
    {
        MyDbContext db = new MyDbContext();

        public UserRepositorySQL() { }

        public List<User> GetAllUsers()
        {
            var result = db.UserEF.OrderBy(u=>u.UserID).ToList();
            return result;
        }

        public User GetById(int id) 
        { 
            var result = db.UserEF.Single(u=>u.UserID == id);
            if(result != null)
            {
                return result;
            }
            result = new User { UserID = -1 };
            return new User();
        }

        public void AddUser(User user) 
        { 
            db.UserEF.Add(user);
            db.SaveChanges();
            Console.WriteLine("Added User to db..");
        }

        public bool UpdateUser(User user) 
        { 
            var currentUser = db.UserEF.Single(u=> u.UserID == user.UserID);
            if (currentUser == null)
            {
                return false;
            } 

            currentUser.Username = user.Username;
            currentUser.Password = user.Password;
            currentUser.Email = user.Email;

            db.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id) { return true; }
    }
}
