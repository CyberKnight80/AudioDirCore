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
                if (string.IsNullOrEmpty(value)) Console.WriteLine("Invalid title");
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
                if (value <= 0) Console.WriteLine("Invalid duration");
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
                if (value <= 0) Console.WriteLine("Invalid release date");
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
        /// <param name="unixreleasedate">Any audio release date in unix</param>
        public Audio(string title, int duration, long unixreleasedate)
        {
            this.Title = title;
            this.Duration = duration;
            this.ReleasedUnix = unixreleasedate;
        }

        #endregion

        #region Methods

        public virtual void About(string Type = "Audio")
        {
            Console.WriteLine($"\nAudio::{Type} Data");
            Console.WriteLine($"{Type} Title: {this.Title}");
            Console.WriteLine($"{Type} Duration: {this.Duration}");
            Console.WriteLine($"{Type} Release Time (Unix): {this.ReleasedUnix}");
            Console.WriteLine("wq!");
        }

        #endregion
    }
}
