using Mopups.Pages;
using Mopups.Services;

namespace AudioAppTests;

public partial class ThemePopup : PopupPage
{
	public ThemePopup()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Application.Current.UserAppTheme = AppTheme.Light;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		Application.Current.UserAppTheme = AppTheme.Dark;
	}

	private async void CloseButtonTapped(object sender, TappedEventArgs e)
	{
		await MopupService.Instance.PopAsync(true);
	}
}