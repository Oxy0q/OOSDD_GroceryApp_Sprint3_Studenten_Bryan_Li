using Grocery.Core.Services;
using Grocery.App.ViewModels;
using Grocery.App.Views;
using Microsoft.Extensions.Logging;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Data.Repositories;
using CommunityToolkit.Maui;

namespace Grocery.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // ---------------------
        // Services
        // ---------------------
        builder.Services.AddSingleton<IGroceryListService, GroceryListService>();
        builder.Services.AddSingleton<IGroceryListItemsService, GroceryListItemsService>();
        builder.Services.AddSingleton<IProductService, ProductService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<IClientService, ClientService>();
        builder.Services.AddSingleton<IFileSaverService, FileSaverService>();
        builder.Services.AddSingleton<IUserService, UserService>();

        // ---------------------
        // Repositories
        // ---------------------
        builder.Services.AddSingleton<IGroceryListRepository, GroceryListRepository>();
        builder.Services.AddSingleton<IGroceryListItemsRepository, GroceryListItemsRepository>();
        builder.Services.AddSingleton<IProductRepository, ProductRepository>();
        builder.Services.AddSingleton<IClientRepository, ClientRepository>();

        // ---------------------
        // Global ViewModel
        // ---------------------
        builder.Services.AddSingleton<GlobalViewModel>();

        // ---------------------
        // Views & ViewModels
        // ---------------------
        builder.Services.AddTransient<GroceryListsView>();
        builder.Services.AddTransient<GroceryListViewModel>();
        builder.Services.AddTransient<GroceryListItemsView>();
        builder.Services.AddTransient<GroceryListItemsViewModel>();
        builder.Services.AddTransient<ProductView>();
        builder.Services.AddTransient<ProductViewModel>();
        builder.Services.AddTransient<ChangeColorView>();
        builder.Services.AddTransient<ChangeColorViewModel>();

        // Important: Register Login and Register views with DI
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterView>();
        builder.Services.AddTransient<RegisterViewModel>();

        // ---------------------
        // Shell routes for navigation
        // ---------------------
        Routing.RegisterRoute("LoginView", typeof(LoginView));
        Routing.RegisterRoute("RegisterView", typeof(RegisterView));

        return builder.Build();
    }
}
