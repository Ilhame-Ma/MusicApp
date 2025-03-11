using MusicApp.Models;
using MusicApp.PageModels;

namespace MusicApp.Pages;

public partial class SongsPage : ContentPage
{
	public SongsPage()
	{
		InitializeComponent();
		BindingContext = new SongsViewModel();
	}

    private async void OnSongSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is SongRead selectedSong)
        {
            await Shell.Current.GoToAsync($"playPage?songId={selectedSong.Id}");
        }
       
    }

}