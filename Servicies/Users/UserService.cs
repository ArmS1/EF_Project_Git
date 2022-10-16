using EF_Project.Entities;
using EF_Project.Helpers;
using EF_Project.ViewModels;

namespace EF_Project.Servicies.Users
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        { 
            return Get(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            // hash password
            //user.PasswordHash = BCrypt.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = Get(id);

            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new Exception("User with the email '" + model.Email + "' already exists");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private User Get(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            return user;
        }
    }
}
