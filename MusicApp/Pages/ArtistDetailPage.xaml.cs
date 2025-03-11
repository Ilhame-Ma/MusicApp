using MusicApp.Models;
using MusicApp.PageModels;
using MusicApp.Services;

namespace MusicApp.Pages;

public partial class ArtistDetailPage : ContentPage
{
	public ArtistDetailPage(ApiService apiService)
	{
		InitializeComponent();
		BindingContext = new ArtistDetailPageModel(apiService);
	}

    private async void OnAlbumSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlbumRead selectedAlbum)
        {
            await Shell.Current.GoToAsync($"albumDetail?albumId={selectedAlbum.Id}");
        }
    }
}