using CommunityToolkit.Mvvm.ComponentModel;
using MusicApp.Models;
using MusicApp.Services;
using System.Collections.ObjectModel;

namespace MusicApp.PageModels
{
    public partial class ArtistPageModel: ObservableObject
    {
        private readonly ApiService apiService;

        [ObservableProperty]
        private ObservableCollection<ArtistRead> artists;

        public ArtistPageModel()
        {
            apiService = new ApiService();
            LoadDataAsync();

        }

        private async void LoadDataAsync()
        {
            var artistsList = await apiService.GetArtistsAsync();
            Artists = new ObservableCollection<ArtistRead>(artistsList);
        }

    }
}
