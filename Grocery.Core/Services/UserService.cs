using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public User? Register(User user)
        {
            if (_users.Any(u => u.Email == user.Email))
                return null; // Email already exists

            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }

        public User? GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}