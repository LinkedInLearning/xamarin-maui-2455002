using NewMauiApp.Handlers;

namespace NewMauiApp;

public partial class App : Application
{
	public App(MainShell startPage)
	{
		InitializeComponent();

		Routing.RegisterRoute("PushedPage", typeof(PushedPage));

        Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping(nameof(ILabel.Text), (handler, view) => { 
        if (view is CurrentLocationDisplay)
            {
                handler.PlatformView.Text = handler.PlatformView.Text + "°";
            }
        });

		MainPage = startPage;
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Activated += Window_Activated;
        window.Resumed += Window_Resumed;

		return window;
    }

    private void Window_Resumed(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Window Resumed");
    }

    private void Window_Activated(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Window Activated ");
    }
}
