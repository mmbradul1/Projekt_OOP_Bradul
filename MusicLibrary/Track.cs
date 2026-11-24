namespace MusicLibrary;
public class Track : IPlayable
{
    public int Id { get => throw new NotImplementedException(); }
    public string Title
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public int DurationSeconds
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public Artist Artist { get => throw new NotImplementedException(); }
    public Genre Genre
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public PlaybackState State { get => throw new NotImplementedException(); }
    internal Track(int id, string title,
        int durationSeconds, Artist artist, Genre genre)
    { throw new NotImplementedException(); }
    public void Play() { throw new NotImplementedException(); }
    public void Pause() { throw new NotImplementedException(); }
    public void Stop() { throw new NotImplementedException(); }
}
