using NewMAUIApp.Library.Interfaces;
using NewMAUIApp.Library.ViewModels;

namespace NewMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainPageViewModel>();

		builder.Services.AddSingleton<ILocation, NewMAUIApp.Library.Platforms.Location>();

		return builder.Build();
	}
}
