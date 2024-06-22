using Proyecto.Application.Models.Dtos;
using Proyecto.Domain.Models;


namespace Proyecto.Application.Repositories
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();

        User GetByName(string name);
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        void UpdateUser(User user);

    }
}
