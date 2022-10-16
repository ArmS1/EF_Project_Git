using EF_Project.Entities;
using EF_Project.ViewModels;

namespace EF_Project.Servicies.Users
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
