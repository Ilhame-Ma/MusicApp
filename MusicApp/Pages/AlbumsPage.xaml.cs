using MusicApp.Models;
using MusicApp.PageModels;
using MusicApp.Services;
using System.Text.Json;

namespace MusicApp.Pages;
public partial class AlbumsPage : ContentPage
{
	public AlbumsPage()
	{
		InitializeComponent();
		BindingContext = new AlbumsViewModel();
	}

    private async void OnAlbumSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlbumRead selectedAlbum)
        {
            await Shell.Current.GoToAsync($"albumDetail?albumId={selectedAlbum.Id}");
        }
    }

}