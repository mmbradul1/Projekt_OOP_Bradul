namespace MusicLibrary;
public class MusicLibrary
{
    private readonly List<Artist> artists = new();
    private readonly List<Album> albums = new();
    private readonly List<User> users = new();

    public IReadOnlyList<Artist> Artists { get => throw new NotImplementedException(); }
    public IReadOnlyList<Album> Albums { get => throw new NotImplementedException(); }
    public IReadOnlyList<User> Users { get => throw new NotImplementedException(); }
    public MusicLibrary() { throw new NotImplementedException(); }
    public bool AddArtist(Artist artist) { throw new NotImplementedException(); }
    public bool AddAlbum(Album album) { throw new NotImplementedException(); }
    public bool AddUser(User user) { throw new NotImplementedException(); }
    public List<Track> FindTracks(string query) { throw new NotImplementedException(); }
}
