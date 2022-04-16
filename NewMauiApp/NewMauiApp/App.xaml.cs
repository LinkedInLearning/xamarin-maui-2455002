namespace NewMauiApp;

public partial class App : Application
{
	public App(MainPage startPage)
	{
		InitializeComponent();

		MainPage = startPage;
	}
}
