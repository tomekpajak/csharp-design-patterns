using System.Collections.Generic;
using static System.Console;

namespace tp.Iterator
{
    class Song
    {
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
    //aggregate
    interface ISongCollection
    {
        ISongIterator GetDefaultIterator();
        ISongIterator GetFavorteIterator();
    }
    //concrete aggregate
    class MediaPlayerSongCollection : ISongCollection
    {
        private List<Song> songs = new List<Song>();
        public void AddSong(Song song) => songs.Add(song);        
        public ISongIterator GetDefaultIterator() => new DefaultSongIterator(this);
        public ISongIterator GetFavorteIterator() => new FavoriteSongIterator(this);
        public int Count => songs.Count;
        public Song this[int index] => songs[index];
    }
    //iterator  
    interface ISongIterator
    {
        Song First();
        Song Next();
        Song Current();
        bool IsLast();
    }
    abstract class SongIterator : ISongIterator
    {
        protected int current = 0;
        protected MediaPlayerSongCollection songs;
        public SongIterator(MediaPlayerSongCollection songs) => this.songs = songs;
        public Song Current() => songs[current];
        public abstract Song First();
        public abstract Song Next();
        public abstract bool IsLast();
    }
    //concrete iterator  
    class DefaultSongIterator : SongIterator
    {
        public DefaultSongIterator(MediaPlayerSongCollection songs) : base(songs)
        {
        }
        public override Song First() => songs[0];
        public override bool IsLast() => current > songs.Count - 1;
        public override Song Next()
        {
            current++;
            if (!IsLast())
                return Current();
            else
                return null;
        }
    }
    //concrete iterator  
    class FavoriteSongIterator : SongIterator
    {
        private int firstFavorite = -1;
        private int lastFavorite = -1;
        public FavoriteSongIterator(MediaPlayerSongCollection songs) : base(songs)
        {
            SetFirstLastFavorite();
            current = firstFavorite;
        }
        public override Song First() => songs[firstFavorite];
        public override bool IsLast() => current > lastFavorite;
        public override Song Next()
        {
            current++;
            if (!IsLast())
            {
                if (!Current().Favorite)
                    return Next();

                return Current();
            }
            else
                return null;
        }
        private void SetFirstLastFavorite()
        {
            for (var i=0; i < songs.Count; i++)
            {
                if (songs[i].Favorite)
                {
                    if (firstFavorite == -1)
                        firstFavorite = i;
                    lastFavorite = i;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mediaPlayer = new MediaPlayerSongCollection();
            mediaPlayer.AddSong(new Song { Name = "song 1", Favorite = false });
            mediaPlayer.AddSong(new Song { Name = "song 2", Favorite = false });
            mediaPlayer.AddSong(new Song { Name = "song 3", Favorite = true });
            mediaPlayer.AddSong(new Song { Name = "song 4", Favorite = false });
            mediaPlayer.AddSong(new Song { Name = "song 5", Favorite = true });
            mediaPlayer.AddSong(new Song { Name = "song 6", Favorite = false });

            WriteLine("Default songs list...");
            ISongIterator iterator = new DefaultSongIterator(mediaPlayer);
            for(var song = iterator.First(); !iterator.IsLast(); song = iterator.Next())
            {
                WriteLine(song.Name);
            }
            
            WriteLine("Favorite songs list...");
            iterator = new FavoriteSongIterator(mediaPlayer);
            for (var song = iterator.First(); !iterator.IsLast(); song = iterator.Next())
            {
                WriteLine(song.Name);
            }
        }
    }
}
