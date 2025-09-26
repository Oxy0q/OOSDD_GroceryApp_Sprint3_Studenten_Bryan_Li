using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly GlobalViewModel _global;

    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string password = string.Empty;
    [ObservableProperty] private string loginMessage;

    public LoginViewModel(IAuthService authService, GlobalViewModel global)
    {
        _authService = authService;
        _global = global;
    }

    [RelayCommand]
    private async Task Login()
    {
        var client = _authService.Login(Email, Password);

        if (client != null)
        {
            _global.Client = client;
            LoginMessage = $"Welkom {client.Name}!";
            // Navigate to main tab page
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            LoginMessage = "Ongeldige inloggegevens.";
        }
    }

    [RelayCommand]
    private async Task NavigateToRegister()
    {
        await Shell.Current.GoToAsync("RegisterView");
    }
}
