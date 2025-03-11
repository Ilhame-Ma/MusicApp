using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicApp.Models;
using MusicApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MusicApp.PageModels;

public partial class ArtistDetailPageModel : ObservableObject, IQueryAttributable
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private ArtistExtended artist;

    [ObservableProperty]
    private ObservableCollection<AlbumRead> albums = new();

    public ArtistDetailPageModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("artistId") && int.TryParse(query["artistId"].ToString(), out int artistId))
        {
            await LoadArtistDetails(artistId);
        }
    }

    private async Task LoadArtistDetails(int artistId)
    {
        Artist = await _apiService.GetArtistByIdAsync(artistId);

        if (Artist?.Albums != null)
            Albums = new ObservableCollection<AlbumRead>(Artist.Albums);
            
    }
}
