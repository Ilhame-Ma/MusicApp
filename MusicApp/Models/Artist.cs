namespace MusicApp.Models;

public class Artist
{
    public string Name { get; set; }
    public string Mbid { get; set;}
    public string Artist_background { get; set;}
    public string Artist_logo { get; set;}
    public string Artist_thumbnail { get; set;}
    public string Artist_banner { get; set;}
}

public class ArtistRead: Artist
{
    public int Id { get; set; }
}

public class ArtistExtended : ArtistRead
{
    public AlbumRead[]? Albums { get; set; }
}
