using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicApp.Models;
using MusicApp.Pages;
using MusicApp.Services;

namespace MusicApp.PageModels;

public partial class AlbumsViewModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private ObservableCollection<AlbumRead> albums;

    public AlbumsViewModel()
    {
        _apiService = new ApiService();
        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var albumsList = await _apiService.GetAlbumsAsync();
        Albums = new ObservableCollection<AlbumRead>(albumsList);
    }

}
