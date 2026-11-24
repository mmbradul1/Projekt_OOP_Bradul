using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicLibrary;

namespace MusicLibrary.Tests;
[TestClass]
public class ArtistTests
{
    [TestMethod]
    public void Constructor_ValidData_PropertiesAssigned()
    {
        Artist artist = new Artist(1, "Adele");

        Assert.AreEqual(1, artist.Id);
        Assert.AreEqual("Adele", artist.Name);
    }

    [TestMethod]
    public void Name_ValidValue_NameChanged()
    {
        Artist artist = new Artist(1, "Adele");

        artist.Name = "Lady Gaga";

        Assert.AreEqual("Lady Gaga", artist.Name);
    }
}

[TestClass]
public class TrackTests
{
    private Track CreateTrack()
    {
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        return album.AddTrack(
            1, "Hello", 295, Genre.Pop);
    }

    [TestMethod]
    public void Constructor_ValidData_PropertiesAssigned()
    {
        Track track = CreateTrack();

        Assert.AreEqual(1, track.Id);
        Assert.AreEqual("Hello", track.Title);
        Assert.AreEqual(295, track.DurationSeconds);
        Assert.AreEqual("Adele", track.Artist.Name);
        Assert.AreEqual(Genre.Pop, track.Genre);
        Assert.AreEqual(PlaybackState.Stopped, track.State);
    }

    [TestMethod]
    public void Properties_ValidValues_Changed()
    {
        Track track = CreateTrack();

        track.Title = "New song";
        track.DurationSeconds = 200;
        track.Genre = Genre.Rock;

        Assert.AreEqual("New song", track.Title);
        Assert.AreEqual(200, track.DurationSeconds);
        Assert.AreEqual(Genre.Rock, track.Genre);
    }

    [TestMethod]
    public void Play_Track_StatePlaying()
    {
        Track track = CreateTrack();

        IPlayable playable = track;
        playable.Play();

        Assert.AreEqual(PlaybackState.Playing, track.State);
    }

    [TestMethod]
    public void Pause_PlayingTrack_StatePaused()
    {
        Track track = CreateTrack();
        track.Play();

        track.Pause();

        Assert.AreEqual(PlaybackState.Paused, track.State);
    }

    [TestMethod]
    public void Stop_PlayingTrack_StateStopped()
    {
        Track track = CreateTrack();
        track.Play();

        track.Stop();

        Assert.AreEqual(PlaybackState.Stopped, track.State);
    }
}

[TestClass]
public class AlbumTests
{
    [TestMethod]
    public void Constructor_ValidData_PropertiesAssigned()
    {
        Artist artist = new Artist(1, "Adele");

        Album album = new Album(1, "25", artist);

        Assert.AreEqual(1, album.Id);
        Assert.AreEqual("25", album.Title);
        Assert.AreSame(artist, album.Artist);
        Assert.AreEqual(0, album.Tracks.Count);
    }

    [TestMethod]
    public void AddTrack_ValidData_TrackCreated()
    {
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        Track track = album.AddTrack(
            1, "Hello", 295, Genre.Pop);

        Assert.AreEqual(1, album.Tracks.Count);
        Assert.AreSame(track, album.Tracks[0]);
    }

    [TestMethod]
    public void GetTotalDuration_TwoTracks_ReturnsSum()
    {
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        album.AddTrack(1, "Hello", 295, Genre.Pop);
        album.AddTrack(2, "Water", 200, Genre.Pop);

        int duration = album.GetTotalDuration();

        Assert.AreEqual(495, duration);
    }

    [TestMethod]
    public void GetTotalDuration_EmptyAlbum_ReturnsZero()
    {
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        Assert.AreEqual(0, album.GetTotalDuration());
    }
}

[TestClass]
public class PlaylistTests
{
    private Playlist CreatePlaylist()
    {
        User user = new User(1, "Alex");

        return user.CreatePlaylist(1, "Favorites");
    }

    private Track CreateTrack()
    {
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        return album.AddTrack(
            1, "Hello", 295, Genre.Pop);
    }

    [TestMethod]
    public void AddTrack_ValidTrack_ReturnsTrue()
    {
        Playlist playlist = CreatePlaylist();
        Track track = CreateTrack();

        bool result = playlist.AddTrack(track);

        Assert.IsTrue(result);
        Assert.AreEqual(1, playlist.Tracks.Count);
        Assert.AreSame(track, playlist.Tracks[0]);
    }

    [TestMethod]
    public void AddTrack_Duplicate_ReturnsFalse()
    {
        Playlist playlist = CreatePlaylist();
        Track track = CreateTrack();

        playlist.AddTrack(track);
        bool result = playlist.AddTrack(track);

        Assert.IsFalse(result);
        Assert.AreEqual(1, playlist.Tracks.Count);
    }

    [TestMethod]
    public void RemoveTrack_ExistingTrack_ReturnsTrue()
    {
        Playlist playlist = CreatePlaylist();
        Track track = CreateTrack();
        playlist.AddTrack(track);

        bool result = playlist.RemoveTrack(1);

        Assert.IsTrue(result);
        Assert.AreEqual(0, playlist.Tracks.Count);
    }

    [TestMethod]
    public void RemoveTrack_NotFound_ReturnsFalse()
    {
        Playlist playlist = CreatePlaylist();

        bool result = playlist.RemoveTrack(999);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GetTotalDuration_OneTrack_ReturnsDuration()
    {
        Playlist playlist = CreatePlaylist();
        playlist.AddTrack(CreateTrack());

        Assert.AreEqual(295, playlist.GetTotalDuration());
    }

    [TestMethod]
    public void GetTotalDuration_EmptyPlaylist_ReturnsZero()
    {
        Playlist playlist = CreatePlaylist();

        Assert.AreEqual(0, playlist.GetTotalDuration());
    }
}

[TestClass]
public class UserTests
{
    [TestMethod]
    public void Constructor_ValidData_PropertiesAssigned()
    {
        User user = new User(1, "Alex");

        Assert.AreEqual(1, user.Id);
        Assert.AreEqual("Alex", user.Name);
        Assert.AreEqual(0, user.Playlists.Count);
    }

    [TestMethod]
    public void CreatePlaylist_ValidData_PlaylistCreated()
    {
        User user = new User(1, "Alex");

        Playlist playlist =
            user.CreatePlaylist(1, "Favorites");

        Assert.AreEqual(1, user.Playlists.Count);
        Assert.AreSame(playlist, user.Playlists[0]);
        Assert.AreEqual("Favorites", playlist.Title);
    }

    [TestMethod]
    public void RemovePlaylist_Existing_ReturnsTrue()
    {
        User user = new User(1, "Alex");
        user.CreatePlaylist(1, "Favorites");

        bool result = user.RemovePlaylist(1);

        Assert.IsTrue(result);
        Assert.AreEqual(0, user.Playlists.Count);
    }

    [TestMethod]
    public void RemovePlaylist_NotFound_ReturnsFalse()
    {
        User user = new User(1, "Alex");

        Assert.IsFalse(user.RemovePlaylist(999));
    }
}

[TestClass]
public class LibraryTests
{
    [TestMethod]
    public void Constructor_NewLibrary_CollectionsEmpty()
    {
        var library = new global::MusicLibrary.MusicLibrary();

        Assert.AreEqual(0, library.Artists.Count);
        Assert.AreEqual(0, library.Albums.Count);
        Assert.AreEqual(0, library.Users.Count);
    }

    [TestMethod]
    public void AddArtist_ValidArtist_ReturnsTrue()
    {
        var library = new global::MusicLibrary.MusicLibrary();
        Artist artist = new Artist(1, "Adele");

        bool result = library.AddArtist(artist);

        Assert.IsTrue(result);
        Assert.AreEqual(1, library.Artists.Count);
    }

    [TestMethod]
    public void AddArtist_Duplicate_ReturnsFalse()
    {
        var library = new global::MusicLibrary.MusicLibrary();
        Artist artist = new Artist(1, "Adele");

        library.AddArtist(artist);
        bool result = library.AddArtist(artist);

        Assert.IsFalse(result);
        Assert.AreEqual(1, library.Artists.Count);
    }

    [TestMethod]
    public void AddAlbum_ValidAlbum_ReturnsTrue()
    {
        var library = new global::MusicLibrary.MusicLibrary();
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);
        library.AddArtist(artist);

        bool result = library.AddAlbum(album);

        Assert.IsTrue(result);
        Assert.AreEqual(1, library.Albums.Count);
    }

    [TestMethod]
    public void AddUser_ValidUser_ReturnsTrue()
    {
        var library = new global::MusicLibrary.MusicLibrary();
        User user = new User(1, "Alex");

        bool result = library.AddUser(user);

        Assert.IsTrue(result);
        Assert.AreEqual(1, library.Users.Count);
    }

    [TestMethod]
    public void FindTracks_ExistingTitle_ReturnsTrack()
    {
        var library = new global::MusicLibrary.MusicLibrary();
        Artist artist = new Artist(1, "Adele");
        Album album = new Album(1, "25", artist);

        Track track = album.AddTrack(
            1, "Hello", 295, Genre.Pop);

        library.AddArtist(artist);
        library.AddAlbum(album);

        var result = library.FindTracks("hello");

        Assert.AreEqual(1, result.Count);
        Assert.AreSame(track, result[0]);
    }

    [TestMethod]
    public void FindTracks_NotFound_ReturnsEmptyList()
    {
        var library = new global::MusicLibrary.MusicLibrary();

        var result = library.FindTracks("Unknown");

        Assert.AreEqual(0, result.Count);
    }
}
