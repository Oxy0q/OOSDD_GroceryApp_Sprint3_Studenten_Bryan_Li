using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    [ObservableProperty] string name;
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string registrationMessage;

    public RegisterViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    public void Register()
    {
        var user = new User(0, Name, Email, Password);
        var result = _userService.Register(user);
        if (result != null)
        {
            RegistrationMessage = "Registration successful!";
            // Optionally navigate to another page
        }
        else
        {
            RegistrationMessage = "Email already exists. Please use a different email.";
        }
    }
}