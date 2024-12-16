using BlazorStock.Shared.Models;

namespace BlazorStock.Server.Repositories.Interface
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetById(int id);
        void AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
