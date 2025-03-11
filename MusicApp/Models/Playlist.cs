namespace MusicApp.Models;

public class Playlist
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class PlaylistRead
{
    public int Id { get; set; }
}

public class PlaylistExtended
{
    public SongRead[]? Songs { get; set; }
}


