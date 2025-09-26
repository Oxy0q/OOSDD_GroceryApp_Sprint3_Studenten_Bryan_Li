using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Grocery.App.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    [ObservableProperty] private string name;
    [ObservableProperty] private string email;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;
    [ObservableProperty] private string registrationMessage;

    public RegisterViewModel()
    {
        // No services needed for now; commands can be stubbed
    }

    [RelayCommand]
    private void Register()
    {
        // For now, just set a placeholder message for unit tests
        RegistrationMessage = "Registration logic not implemented yet.";
    }
}
