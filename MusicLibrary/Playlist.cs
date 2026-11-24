namespace MusicLibrary;
public class Playlist
{
    private readonly List<Track> tracks = new();
    public int Id { get => throw new NotImplementedException(); }
    public string Title
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public IReadOnlyList<Track> Tracks { get => throw new NotImplementedException(); }
    internal Playlist(int id, string title) { throw new NotImplementedException(); }
    public bool AddTrack(Track track) { throw new NotImplementedException(); }
    public bool RemoveTrack(int id) { throw new NotImplementedException(); }
    public int GetTotalDuration() { throw new NotImplementedException(); }
}
