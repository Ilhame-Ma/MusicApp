using CommunityToolkit.Mvvm.ComponentModel;
using MusicApp.Models;
using MusicApp.Services;

namespace MusicApp.PageModels;

public partial class AlbumDetailViewModel : ObservableObject, IQueryAttributable
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private AlbumExtended album;

    public AlbumDetailViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("albumId"))
        {
            int albumId = int.Parse(query["albumId"].ToString());
            await LoadAlbumDetails(albumId);
        }
    }

    private async Task LoadAlbumDetails(int albumId)
    {
        Album = await _apiService.GetAlbumByIdAsync(albumId);
    }
}
