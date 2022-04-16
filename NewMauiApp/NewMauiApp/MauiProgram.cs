using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.LifecycleEvents;
using NewMauiApp.Controls;
using NewMauiApp.Effects;
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
		builder.Services.AddTransient<LifecyclePageViewModel>();
		builder.Services.AddTransient<LifecyclePage>();
		builder.Services.AddTransient<MainShell>();
		builder.Services.AddTransient<EffectsPage>();

#if ANDROID
		builder.ConfigureLifecycleEvents(events => { 
			events.AddAndroid(android => {
				android.OnRequestPermissionsResult((activity, requestCode, resultCode, data) =>
				{
					Platform.OnRequestPermissionsResult(requestCode, resultCode, data);
				});
			});
		});
#endif
		builder.ConfigureEffects(effects => {
#if ANDROID
			effects.Add<TextColorEffect, Platforms.Android.Effects.TextColorEffect>();
#endif

		});

		builder.UseMauiCompatibility();
		builder.ConfigureMauiHandlers(handlers => {
#if ANDROID
			handlers.AddCompatibilityRenderer(typeof(AutoSelectEntry), typeof(Platforms.Android.Renderers.AutoSelectEntryRenderer));
#endif

		});

		builder.Services.AddSingleton<ILocation, NewMAUIApp.Library.Platforms.Location>();

		return builder.Build();
	}
}
