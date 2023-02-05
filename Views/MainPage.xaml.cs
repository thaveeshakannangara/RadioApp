using Mopups.Services;

namespace AudioAppTests;

public partial class MainPage : ContentPage
{
	private bool isPlaying = false;
	private bool isMuted = false;

	public bool IsMuted
	{
		get => isMuted;
		set
		{
			if (isMuted == value) return;
			isMuted = value;
		}
	}

	public MainPage()
	{
		InitializeComponent();
		mediaElement.Volume = Convert.ToDouble(0.5);
	}

	private void PlayButtonTapped(object sender, TappedEventArgs e)
	{
		if (isPlaying)
		{
			playIcon.Source = "play_edited.png";
			mediaElement.Pause();
			isPlaying = false;
			playThumbnail.IsVisible = true;
			skLottieView.IsVisible = false;
		}
		else
		{
			playIcon.Source = "pause_edited.png";
			mediaElement.Play();
			isPlaying = true;
			playThumbnail.IsVisible = false;
			skLottieView.IsVisible = true;
		}
	}

	private void VolumeChanged(object sender, ValueChangedEventArgs e)
	{
		if (e.OldValue != e.NewValue)
		{
			mediaElement.Volume = e.NewValue;
			volumeText.Text = $"{double.Truncate(e.NewValue * 100)}%";
		}
	}

	private void MuteButtonTapped(object sender, TappedEventArgs e)
	{
		if (isMuted)
		{
			volumeSlider.Value = 0.5;
			IsMuted = false;
		}
		else
		{
			volumeSlider.Value = 0;
			IsMuted = true;
		}
	}

	private async void InfoButtonTapped(object sender, TappedEventArgs e)
	{
		var page = new ThemePopup();
		await MopupService.Instance.PushAsync(page);
	}
}