using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirLab
{

    #region Loader

    public class Loader
    {

        #region Factory

        /// <summary>
        /// Creates an object of type Audio based on the passed string of data
        /// </summary>
        /// <param name="StringObject">Data string for object creation</param>
        /// <returns>Created Audio object</returns>
        public static Audio CreateObject(string StringObject)
        {
            string[] args = StringObject.Split('|');
            string AudioType = args[0];

            switch (AudioType)
            {
                case "Song":
                    return new Song(args[1], int.Parse(args[2]), int.Parse(args[3]), args[4], args[5]);
                case "Podcast":
                    return new Podcast(args[1], int.Parse(args[2]), int.Parse(args[3]), args[4], int.Parse(args[5]), int.Parse(args[6]));
                case "AudioBook":
                    return new AudioBook(args[1], int.Parse(args[2]), int.Parse(args[3]), args[4], args[5], int.Parse(args[6]));
                default:
                    throw new InvalidSavedData(StringObject);
            }
        }

        #endregion

        #region Saving and Loading

        /// <summary>
        /// Saves a list of Audio objects to the specified file
        /// </summary>
        /// <param name="filename">File name to save data</param>
        /// <param name="objects">List of Audio objects to save</param>
        public static void SaveObjects(string filename, List<Audio> objects)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Audio audio in objects)
                {
                    sw.WriteLine(audio.ToString());
                }
            }
        }

        /// <summary>
        /// Loads a list of Audio objects from the specified file
        /// </summary>
        /// <param name="filename">File name to download data</param>
        /// <returns>List of Audio objects loaded from the file</returns>
        public static List<Audio> LoadObjects(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundError(filename);

            List<Audio> objects = new List<Audio>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string SavedObject;
                while ((SavedObject = sr.ReadLine()!) != null)
                {
                    objects.Add(CreateObject(SavedObject));
                }
            }
            return objects;
        }

        #endregion

    }

    #endregion

    #region Custom Exceptions

    /// <summary>
    /// The exception thrown when there is a file missing error
    /// </summary>
    public class FileNotFoundError : Exception
    {
        /// <summary>
        /// Creates a new instance of the FileNotFoundError class specifying the file name
        /// </summary>
        /// <param name="filename">The name of the file that was not found<param>
        public FileNotFoundError(string filename) : base(filename)
        {
            string ErrorMessage = $"ERROR: File  \"{filename}\" not found. Exiting...";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage);

            Environment.Exit(1);
        }
    }

    /// <summary>
    /// The exception thrown when the upperand value is incorrect
    /// </summary>
    public class InvalidValueError : Exception
    {
        /// <summary>
        /// Creates a new instance of the InvalidValueError class specifying the upperand, value, and error message
        /// </summary>
        /// <param name="apperand">An upperand that is set to an incorrect value</param>
        /// <param name="value">Incorrect upperand value</param>
        /// <param name="message">Error message</param>
        public InvalidValueError(string apperand, string value, string message) : base(message)
        {
            string ErrorMessage = $"WARNING: Apperand {apperand} cannot be set to {value}: {message}";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ErrorMessage);

            Console.ResetColor();
        }
    }

    /// <summary>
    /// The exception thrown when there is a broken saved data in file
    /// </summary>
    public class InvalidSavedData : Exception
    {
        /// <summary>
        /// Creates a new instance of the InvalidSavedData class
        /// </summary>
        /// <param name="data">The invalid data<param>
        public InvalidSavedData(string data) : base(data)
        {
            string ErrorMessage = $"ERROR: Invaild data: {data}. Exiting...";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage);

            Environment.Exit(1);

        }
    }

    #endregion 
}