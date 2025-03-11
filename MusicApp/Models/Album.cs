namespace MusicApp.Models;

public class Album
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Picture { get; set; }
    public string Mbid { get; set; }
    public int ArtistId { get; set; }
}

public class AlbumRead : Album
{
    public int Id { get; set; }
}

public class AlbumExtended : AlbumRead
{
    public ArtistRead? Artist { get; set; }
    public SongRead[]? Songs { get; set; }
}
