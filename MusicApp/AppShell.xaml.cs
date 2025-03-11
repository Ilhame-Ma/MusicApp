using MusicApp.Pages;

namespace MusicApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("albumDetail", typeof(AlbumDetailPage));
            Routing.RegisterRoute("artistDetail", typeof(ArtistDetailPage));
            Routing.RegisterRoute("playPage", typeof(PlayPage));
        }
    }
}
