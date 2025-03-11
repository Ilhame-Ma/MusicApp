using MusicApp.Models;
using MusicApp.PageModels;
using MusicApp.Services;

namespace MusicApp.Pages;

public partial class InicioPage : ContentPage
{
	public InicioPage(ApiService apiService)
	{
		InitializeComponent();
        BindingContext = new InicioPageModel(apiService);
    }

    private async void OnArtistTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlbumRead selectedAlbum)
        {
            await Shell.Current.GoToAsync($"//albumDetail?albumId={selectedAlbum.Id}");
        }
    }
    private void OnSongTapped(object sender, EventArgs e)
    {
        var selectedFrame = (Frame)sender;
        var selectedSong = (Artist)selectedFrame.BindingContext;

        if (_selectedartistFrame != null)
        {
            _selectedartistFrame.BackgroundColor = Colors.DarkGray; 
        }

        selectedFrame.BackgroundColor = Colors.LightGreen; 
        _selectedartistFrame = selectedFrame;
    }

    private Frame _selectedartistFrame;
}