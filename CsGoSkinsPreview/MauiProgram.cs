using CsGoSkinsPreview.Remote.Interfaces;
using CsGoSkinsPreview.Remote.Remote;
namespace CsGoSkinsPreview;

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
		builder.Services.AddScoped<IApiHelper, ApiHelper>();
		builder.Services.AddScoped<IApiCaller, ApiCaller>();

		return builder.Build();
	}
}
