using MusicApp.Models;
using MusicApp.PageModels;

namespace MusicApp.Pages;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage()
	{
		InitializeComponent(); 
        BindingContext = new ArtistPageModel();
    }

    private async void OnArtistSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ArtistExtended selectedArtist)
        {
            await Shell.Current.GoToAsync($"artistDetail?artistId={selectedArtist.Id}");
        }

    }
}