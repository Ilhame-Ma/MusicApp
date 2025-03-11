using CommunityToolkit.Mvvm.ComponentModel;
using MusicApp.Models;
using MusicApp.Services;

namespace MusicApp.PageModels
{
    public partial class PlayPageModel : ObservableObject, IQueryAttributable
    {
        private readonly ApiService _apiService;

        [ObservableProperty]
        private SongRead song;

        public PlayPageModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("songId"))
            {
                int songId = int.Parse(query["songId"].ToString());
                await LoadSongDetails(songId);
            }
        }

        private async Task LoadSongDetails(int songId)
        {
            Song = await _apiService.GetSongByIdAsync(songId);
        }
    }
}
