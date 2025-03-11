namespace MusicApp.Models;

public class Genre
{
    public string Name { get; set; }
}

public class GenreRead : Genre
{
    public int Id { get; set; }
}

public class GenreExtended : GenreRead
{
    public SongRead[]? Songs { get; set; }
}



