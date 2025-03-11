using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicApp.Models;
using MusicApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MusicApp.PageModels;

public partial class InicioPageModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private ObservableCollection<SongExtended> songs = new();

    [ObservableProperty]
    private ObservableCollection<AlbumExtended> albums = new();

    [ObservableProperty]
    private ObservableCollection<ArtistExtended> artists = new();

    public InicioPageModel(ApiService apiService)
    {
        _apiService = apiService;
        LoadDataSongs();
        LoadDataAlbums();
        LoadDataArtists();
    }

    private async void LoadDataSongs()
    {
        var listSongs = await _apiService.GetSongsAsync();
        if (listSongs != null)
            Songs = new ObservableCollection<SongExtended>(listSongs.Take(9));
    }

    private async void LoadDataAlbums()
    {
        var listAlbums = await _apiService.GetAlbumsAsync();
        if (listAlbums != null)
            Albums = new ObservableCollection<AlbumExtended>(listAlbums);
    }

    private async void LoadDataArtists()
    {
        var listArtists = await _apiService.GetArtistsAsync();
        if (listArtists != null)
            Artists = new ObservableCollection<ArtistExtended>(listArtists);
    }

    [RelayCommand]
    private async Task SelectArtistAsync(ArtistExtended artist)
    {
        if (artist != null)
        {
            var selectedArtist = Artists.FirstOrDefault(a => a.Id == artist.Id);

            if (selectedArtist != null)
            {
                await Shell.Current.GoToAsync($"//artistDetail?albumId={selectedArtist.Id}");
            }
        }
    }

    [RelayCommand]
    private async Task SelectSongAsync(SongExtended song)
    {
        if (song != null)
        {
            var selectedSong = Songs.FirstOrDefault(a => a.Id == song.Id);

            if (selectedSong != null)
            {
                await Shell.Current.GoToAsync($"//playPage?albumId={selectedSong.Id}");
            }
        }
    }

    [RelayCommand]
    private async Task SelectAlbumAsync(AlbumExtended album)
    {
        if (album != null)
        {
            var selectedAlbum = Albums.FirstOrDefault(a => a.Id == album.Id);

            if (selectedAlbum != null)
            {
                await Shell.Current.GoToAsync($"//albumDetail?albumId={selectedAlbum.Id}");
            }
        }
    }
}
