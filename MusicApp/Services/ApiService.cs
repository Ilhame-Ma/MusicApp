using MusicApp.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace MusicApp.Services;

public class ApiService
{
    private const string BaseUrl = "http://localhost:8079/";
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri(BaseUrl) };
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = true
    };

    public async Task<List<SongExtended>> GetSongsAsync() =>
        await GetDataAsync<List<SongExtended>>("songs");

    public async Task<List<AlbumExtended>> GetAlbumsAsync() =>
        await GetDataAsync<List<AlbumExtended>>("albums");

    public async Task<List<ArtistExtended>> GetArtistsAsync() =>
        await GetDataAsync<List<ArtistExtended>>("artists");

    public async Task<AlbumExtended> GetAlbumByIdAsync(int albumId) =>
        await GetDataAsync<AlbumExtended>($"albums/{albumId}");

    public async Task<SongRead> GetSongByIdAsync(int songId) =>
        await GetDataAsync<SongRead>($"songs/{songId}");

    public async Task<ArtistExtended> GetArtistByIdAsync(int artistId) =>
        await GetDataAsync<ArtistExtended>($"artists/{artistId}");

    public async Task<List<SongExtended>> SearchSongsAsync(string query)
    {
        return await GetDataAsync<List<SongExtended>>($"songs/search?query={query}");
    }

    public async Task<List<AlbumExtended>> SearchAlbumsAsync(string query)
    {
        return await GetDataAsync<List<AlbumExtended>>($"albums/search?query={query}");
    }

    private async Task<T> GetDataAsync<T>(string endpoint)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<T>(endpoint, _serializerOptions);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
            return default;
        }
    }

}