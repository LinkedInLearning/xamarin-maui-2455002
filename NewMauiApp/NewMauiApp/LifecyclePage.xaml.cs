using NewMAUIApp.Library.ViewModels;

namespace NewMauiApp;

public partial class LifecyclePage : ContentPage
{
	public LifecyclePage(LifecyclePageViewModel lifecyclePageViewModel)
	{
		InitializeComponent();
		
		BindingContext = lifecyclePageViewModel;
	}
}