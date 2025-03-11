namespace MusicApp.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    private async void OnWebsiteClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("http://patience-is-a-virtue.org/");
    }
}