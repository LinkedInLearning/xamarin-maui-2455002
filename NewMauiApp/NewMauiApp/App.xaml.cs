namespace NewMauiApp;

public partial class App : Application
{
	public App(MainShell startPage)
	{
		InitializeComponent();

		Routing.RegisterRoute("PushedPage", typeof(PushedPage));

		MainPage = startPage;
	}
}
