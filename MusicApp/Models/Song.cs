namespace MusicApp.Models;

public class Song
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }
    public int Track_num { get; set; }
    public string File { get; set; }
    public int Album_id { get; set; }
    public int Genre_id { get; set; }
}

public class SongRead: Song
{
    public int Id { get; set; }
}

public class SongExtended: SongRead
{
    public AlbumRead Album { get; set; }
    public GenreRead Genre { get; set; }
    public PlaylistRead[]? Playlists { get; set; }  
}
