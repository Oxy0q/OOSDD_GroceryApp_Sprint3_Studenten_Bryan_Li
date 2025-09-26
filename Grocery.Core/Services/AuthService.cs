using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;

    public AuthService(IUserService userService)
    {
        _userService = userService;
    }

    public Client Login(string email, string password)
    {
        var user = _userService.GetByEmail(email);
        if (user != null && user.Password == password)
        {
            // Pass all required arguments to Client constructor
            return new Client(user.Id, user.Name, user.Email, user.Password);
        }

        return null;
    }
}
