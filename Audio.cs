using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirLab
{
    /// <summary>
    /// Abstract class that creates any audio object
    /// </summary>
    public abstract class Audio
    {

        #region Fields

        /// <summary>
        /// Title of any audio object
        /// </summary>
        protected string __title = "No title";

        /// <summary>
        /// Duration of any audio object
        /// </summary>
        protected int __duration = 0;

        /// <summary>
        /// Unix time when audio released
        /// </summary>
        protected long __unixreleasedate = 0;

        #endregion

        #region Fields Access

        /// <summary>
        /// Access to audio title
        /// </summary>
        public string Title
        {
            get { return this.__title;  }
            set
            {
                if (string.IsNullOrEmpty(value)) new InvalidValueError("Title", value, "null or empty");
                else this.__title = value;
            }
        }

        /// <summary>
        /// Access to audio duration (seconds)
        /// </summary>
        public int Duration
        {
            get { return this.__duration; }
            set
            {
                if (value <= 0) new InvalidValueError("Duration", value.ToString(), "bellow or asserts zero");
                else this.__duration = value;
            }
        }

        /// <summary>
        /// Access to audio release date
        /// </summary>
        public long ReleasedUnix
        {
            get { return this.__unixreleasedate; }
            set
            {
                if (value <= 0) new InvalidValueError("ReleasedUnix", value.ToString(), "bellow or asserts zero");
                else this.__unixreleasedate = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Any audio constructor
        /// </summary>
        /// <param name="title">Any audio title</param>
        /// <param name="duration">Any audio duration (seconds)</param>
        /// <param name="unixReleaseDate">Any audio release date in unix</param>
        public Audio(string title, int duration, long unixReleaseDate)
        {
            this.Title = title;
            this.Duration = duration;
            this.ReleasedUnix = unixReleaseDate;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Console WriteLine Data about object
        /// </summary>
        /// <param name="Type"></param>
        public virtual void About(string Type = "Audio")
        {
            Console.WriteLine($"\nAudio::{Type} Data");
            Console.WriteLine($"{Type} title: {this.Title}");
            Console.WriteLine($"{Type} duration: {this.Duration}s");
            Console.WriteLine($"{Type} release time (unix): {this.ReleasedUnix}");
        }

        #endregion
    }
}
