using MusicApp.Models;
using MusicApp.PageModels;

namespace MusicApp.Pages;

public partial class AlbumDetailPage : ContentPage
{

    public AlbumDetailPage(AlbumDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnAlbumSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlbumRead selectedAlbum)
        {
            await Shell.Current.GoToAsync($"albumDetail?albumId={selectedAlbum.Id}");
        }
    }

}
