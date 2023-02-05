using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Mopups.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace AudioAppTests;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureMopups()
			.UseMauiCommunityToolkitMediaElement()
			.ConfigureLifecycleEvents(events =>
			{
#if IOS
						events.AddiOS(ios => ios
							.FinishedLaunching((app, options) =>
							{
								AVFoundation.AVAudioSession session = AVFoundation.AVAudioSession.SharedInstance();
								session.SetCategory(AVFoundation.AVAudioSessionCategory.Playback);
								session.SetActive(true);
								return true;
							}));
#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("NewYorkSmall-Bold.ttf", "NewYorkSmallBold");
				fonts.AddFont("NewYorkSmall-Semibold.ttf", "NewYorkSmallSemibold");
				fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
				fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
			});
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}