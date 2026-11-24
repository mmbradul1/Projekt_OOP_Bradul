namespace MusicLibrary;
public class Album
{
    private readonly List<Track> tracks = new();
    public int Id { get => throw new NotImplementedException(); }
    public string Title
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public Artist Artist { get => throw new NotImplementedException(); }
    public IReadOnlyList<Track> Tracks { get => throw new NotImplementedException(); }
    public Album(int id, string title, Artist artist) { throw new NotImplementedException(); }
    public Track AddTrack(int id, string title,
        int durationSeconds, Genre genre)
    { throw new NotImplementedException(); }
    public int GetTotalDuration() { throw new NotImplementedException(); }
}
