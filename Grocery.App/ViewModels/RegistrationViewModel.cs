using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

public partial class RegistrationViewModel : ObservableObject
{
    [ObservableProperty] string username;
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string registrationMessage;

    [RelayCommand]
    public async Task Register()
    {
        // TODO: Replace with actual UCx registration API call
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            RegistrationMessage = "Please fill in all fields.";
            return;
        }

        // Simulate registration success
        RegistrationMessage = "Registration successful!";
    }
}