using Grocery.App.ViewModels;
using Grocery.App.Views;

namespace Grocery.App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell(); // Shell handles navigation
    }
}
