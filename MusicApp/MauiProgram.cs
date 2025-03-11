using Microsoft.Extensions.Logging;
using MusicApp.PageModels;
using MusicApp.Pages;
using MusicApp.Services;
using CommunityToolkit.Maui;

namespace MusicApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkitMediaElement().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ApiService>();

            builder.Services.AddTransient<SongsPage>();
            builder.Services.AddTransient<SongsViewModel>();

            builder.Services.AddTransient<PlayPage>();
            builder.Services.AddTransient<PlayPageModel>();

            builder.Services.AddTransient<AlbumsPage>();
            builder.Services.AddTransient<AlbumsViewModel>();

            builder.Services.AddTransient<AlbumDetailViewModel>();
            builder.Services.AddTransient<AlbumDetailPage>();

            builder.Services.AddTransient<InicioPage>();
            builder.Services.AddTransient<InicioPageModel>();

            builder.Services.AddTransient<ArtistsPage>();
            builder.Services.AddTransient<ArtistPageModel>();

            builder.Services.AddTransient<ArtistDetailPage>();
            //builder.Services.AddTransient<ArtistDetailPageModel>();
            return builder.Build();
        }
    }
}