namespace MusicLibrary;
public class User
{
    private readonly List<Playlist> playlists = new();
    public int Id { get => throw new NotImplementedException(); }
    public string Name
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public IReadOnlyList<Playlist> Playlists { get => throw new NotImplementedException(); }
    public User(int id, string name) { throw new NotImplementedException(); }
    public Playlist CreatePlaylist(int id, string title) { throw new NotImplementedException(); }
    public bool RemovePlaylist(int id) { throw new NotImplementedException(); }
}
