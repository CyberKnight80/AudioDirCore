using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirCore
{
    /// <summary>
    /// Class that uses Audio to create Song (like Radiohead - No surprises)
    /// </summary>
    public class Song : Audio
    {
        
        #region Fields
        
        /// <summary>
        /// Song Album Title (like OK COMPUTER)
        /// </summary>
        protected string __album = "Untitled album";

        /// <summary>
        /// Song Artist(Group) (like Radiohead)
        /// </summary>
        protected string __artist = "Untitled artist";

        #endregion

        #region Fields Access

        /// <summary>
        /// Access to song album title
        /// </summary>
        public string AlbumTitle
        {
            get { return this.__album; }
            set
            {
                if (string.IsNullOrEmpty(value)) new InvalidValueError("AlbumTitle", value, "null or empty");
                else this.__album = value;
            }
        }

        /// <summary>
        /// Access to song artits title
        /// </summary>
        public string ArtistTitle
        {
            get { return this.__artist; }
            set
            {
                if (string.IsNullOrEmpty(value)) new InvalidValueError("ArtistTitle", value, "null or empty");
                else this.__artist = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Song constructor from Audio
        /// </summary>
        /// <param name="albumTitle">Album title</param>
        /// <param name="artistTitle">Artist title</param>
        public Song(string title, int duration, long unixReleaseDate, string albumTitle, string artistTitle) : base(title, duration, unixReleaseDate)
        {
            this.AlbumTitle = albumTitle;
            this.ArtistTitle = artistTitle;
        }

        #endregion

        #region Methods

        public override void About(string Type = "Song")
        {
            base.About(Type);
            Console.WriteLine($"{Type} album title: {this.AlbumTitle}");
            Console.WriteLine($"{Type} artist title: {this.ArtistTitle}");
            Console.WriteLine("w!");
        }

        public override string ToString()
        {
            return $"Song|{this.Title}|{this.Duration}|{this.ReleasedUnix}|{this.AlbumTitle}|{this.ArtistTitle}";
        }

        #endregion

    }
}
