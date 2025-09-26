using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IUserService
    {
        User? Register(User user);
        User? GetByEmail(string email);
    }
}