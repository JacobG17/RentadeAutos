using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace Rentade;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("ArchivoNarrow-Italic-VariableFont_wght.ttf", "ArchivoNarrow");
				fonts.AddFont("Manrope-VariableFont_wght.ttf", "Manrope_wght");
                fonts.AddFont("Manrope-Regular.ttf", "Manrope_Regular");
                fonts.AddFont("Manrope-Medium.ttf", "Manrope_Medium");
                fonts.AddFont("Manrope-ExtraBold.ttf", "Manrope_BOLD");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto-regular");
                fonts.AddFont("Roboto-Medium.ttf", "Roboto-Medium");
                fonts.AddFont("Roboto-Italic.ttf", "Roboto-Italic");
                fonts.AddFont("Roboto-BoldItalic.ttf", "Roboto-BoldItalic");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

