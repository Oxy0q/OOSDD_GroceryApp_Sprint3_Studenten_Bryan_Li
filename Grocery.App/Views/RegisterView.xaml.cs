using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class RegisterView : ContentPage
    {
        // Constructor with DI-provided ViewModel
        public RegisterView(RegisterViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; // Set the BindingContext here
        }
    }
}
