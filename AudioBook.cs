using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirLab
{
    public class AudioBook : Audio
    {
        #region Fields

        /// <summary>
        /// AudioBook author title (like George Orwell)
        /// </summary>
        protected string __author = "Untitled author";

        /// <summary>
        /// AudioBook genre (like novel)
        /// </summary>
        protected string __genre = "Untitled genre";

        /// <summary>
        /// AudioBook age limit (like 18+)
        /// </summary>
        protected int __agelimit = -1;

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
        /// Access to audiobook genre
        /// </summary>
        public string Genre
        {
            get { return this.__genre; }
            set
            {
                if (string.IsNullOrEmpty(value)) new InvalidValueError("Genre", value, "null or empty");
                else this.__genre = value;
            }
        }

        /// <summary>
        /// Access to audiobook age limit
        /// </summary>
        public int AgeLimit
        {
            get { return this.__agelimit ; }
            set
            {
                if (value <= 0) new InvalidValueError("AgeLimit", value.ToString(), "bellow or asserts zero");
                else this.__agelimit = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// AudioBook constructor from Audio
        /// </summary>
        /// <param name="authorTitle">Author title</param>
        /// <param name="genre">AudioBook genre</param>
        /// /// <param name="ageLimit">AudioBook age limit</param>
        public AudioBook(string title, int duration, long unixReleaseDate, string authorTitle, string genre, int ageLimit) : base(title, duration, unixReleaseDate)
        {
            this.AuthorTitle = authorTitle;
            this.Genre = genre;
            this.AgeLimit = ageLimit;
        }

        #endregion

        #region Methods

        public override void About(string Type = "Podcast")
        {
            base.About(Type);
            Console.WriteLine($"{Type} author title: {this.AuthorTitle}");
            Console.WriteLine($"{Type} genre: {this.Genre}");
            Console.WriteLine($"{Type} age limit: {this.AgeLimit}+");
            Console.WriteLine("w!");
        }

        public override string ToString()
        {
            return $"AudioBook|{this.Title}|{this.Duration}|{this.ReleasedUnix}|{this.AuthorTitle}|{this.Genre}|{this.AgeLimit}";
        }

        #endregion
    }
}
