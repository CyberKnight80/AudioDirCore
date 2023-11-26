using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirLab
{
    public class Podcast : Audio
    {

        #region Fields

        /// <summary>
        /// Podcast author title (like PODLODKA)
        /// </summary>
        protected string __author = "Untitled author";

        /// <summary>
        /// Podcast season (like 5th season)
        /// </summary>
        protected int __season = -1;

        /// <summary>
        /// Podcast episode (like 1th episode)
        /// </summary>
        protected int __episode = -1;

        #endregion

        #region Fields Access

        /// <summary>
        /// Access to podcast author title
        /// </summary>
        public string AuthorTitle
        {
            get { return this.__author; }
            set
            {
                if (string.IsNullOrEmpty(value)) new InvalidValueError("AuthorTitle", value, "null or empty");
                else this.__author = value;
            }
        }

        /// <summary>
        /// Access to podcast season
        /// </summary>
        public int Season
        {
            get { return this.__season; }
            set
            {
                if (value <= 0) new InvalidValueError("Season", value.ToString(), "bellow or asserts zero");
                else this.__season = value;
            }
        }

        /// <summary>
        /// Access to podcast episode
        /// </summary>
        public int Episode
        {
            get { return this.__episode; }
            set
            {
                if (value <= 0) new InvalidValueError("Episode", value.ToString(), "bellow or asserts zero");
                else this.__episode = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Podcast constructor from Audio
        /// </summary>
        /// <param name="authorTitle">Author title</param>
        /// <param name="season">Podcast season</param>
        /// /// <param name="episode">Podcast episode</param>
        public Podcast(string title, int duration, long unixReleaseDate, string authorTitle, int season, int episode) : base(title, duration, unixReleaseDate)
        {
            this.AuthorTitle = authorTitle;
            this.Season = season;
            this.Episode = episode;
        }

        #endregion

        #region Methods

        public override void About(string Type = "Podcast")
        {
            base.About(Type);
            Console.WriteLine($"{Type} author title: {this.AuthorTitle}");
            Console.WriteLine($"{Type} season: {this.Season}");
            Console.WriteLine($"{Type} episode: {this.Episode}");
            Console.WriteLine("w!");
        }

        public override string ToString()
        {
            return $"Podcast|{this.Title}|{this.Duration}|{this.ReleasedUnix}|{this.AuthorTitle}|{this.Season}|{this.Episode}";
        }

        #endregion

    }
}
