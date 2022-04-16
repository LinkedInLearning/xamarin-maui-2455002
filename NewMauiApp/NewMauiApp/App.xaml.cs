namespace NewMauiApp;

public partial class App : Application
{
	public App(MainShell startPage)
	{
		InitializeComponent();

		MainPage = startPage;
	}
}
