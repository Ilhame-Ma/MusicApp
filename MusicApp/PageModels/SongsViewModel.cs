using CommunityToolkit.Mvvm.ComponentModel;
using MusicApp.Models;
using MusicApp.Pages;
using MusicApp.Services;
using System.Collections.ObjectModel;

namespace MusicApp.PageModels;

public partial class SongsViewModel : ObservableObject
{
    private readonly ApiService apiService;

    [ObservableProperty]
    private ObservableCollection<SongRead> songs;

    public SongsViewModel()
    { 
        apiService = new ApiService();
        LoadDataAsync();

    }

    private async void LoadDataAsync()
    {
        var songsList = await apiService.GetSongsAsync();
        if (songsList == null)
        {
            songsList = new List<SongExtended>();
        }
        Songs = new ObservableCollection<SongRead>(songsList);
    }

}
