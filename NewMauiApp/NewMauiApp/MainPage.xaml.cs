using NewMAUIApp.Library.ViewModels;

namespace NewMauiApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainPageViewModel();
    }
}

