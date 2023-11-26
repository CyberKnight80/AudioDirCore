using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirLab
{
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
                    throw new ArgumentException("Invalid saved data");
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
                throw new ArgumentException($" file not found error: {filename}"); // FileNotFoundError

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
}
