using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AudioDirCore
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

            Logger.Log(ErrorMessage);
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

            Logger.Log(ErrorMessage);
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

            Logger.Log(ErrorMessage);
            Environment.Exit(1);

        }
    }

    #endregion

    #region Logger Class

    /// <summary>
    /// The Logger class is designed to log messages and display information about program startup.
    /// </summary>
    public class Logger
    {
        #region Singleton Implementation

        // Static variable for singleton implementation
        private static Logger instance;

        // Object to block the thread when creating a singleton
        private static object lockObject = new object();

        #endregion

        #region Constants and Fields

        // Directory for storing logs
        private const string LoggerFolder = "logs";

        // Timestamp format for log file name
        public static string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

        // Current log file name
        public static string logFileName = $"{LoggerFolder}\\{timestamp}.log";

        #endregion

        #region Constructor and Initialization

        /// <summary>
        /// The static constructor of the Logger class performs initialization, creating a log folder and starting writing to a new log file.
        /// </summary>
        static Logger()
        {
            if (!Directory.Exists(LoggerFolder)) { Directory.CreateDirectory(LoggerFolder); }

            // Creating a new log file with the current timestamp
            using (File.Create(logFileName)) { };

            // Logging information about program launch
            Log("AudioDirLab loaded. Logger created");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get an instance of the Logger class. Singleton implementation.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion

        #region Logging Methods

        /// <summary>
        /// Writes a message to the current log file.
        /// </summary>
        /// <param name="message">Logging message</param>
        public static void Log(string message)
        {
            try
            {
                // Open the log file to add an entry
                using (StreamWriter writer = File.AppendText(logFileName))
                {
                    // Write the timestamp and message to the log
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
                }
            }
            catch (IOException e)
            {
                // Handling a log entry error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The log cannot be written: {e.Message}");
                Environment.Exit(1);
            }
        }

        #endregion
    }

    #endregion

    #region Comparators

    public interface IUniversal
    {
        public List<String> Print();

        public void SortInt();

        public void SortString();

    }
    public class StringComparator : IComparer<Audio>
    {
        int IComparer<Audio>.Compare(Audio? x, Audio y)
        {
            return x!.Title.CompareTo(y.Title);
        }
    }
    public interface ICompareAudio : IComparer<Audio>
    {
        int IComparer<Audio>.Compare(Audio? a, Audio? b)
        {
            if (a is not null && b is not null)
            {
                if (a.Duration > b.Duration) return 1;
                if (a.Duration < b.Duration) return -1;
            }

            return 0;
        }
    }

    public class IntComparator : IComparer<Audio>
    {
        int IComparer<Audio>.Compare(Audio? x, Audio y)
        {
            return x!.Duration.CompareTo(y.Duration);
        }
    }

    #endregion

    #region AudioList

    public class AudioList : IEnumerable<Audio>, IUniversal
    {
        private List<Audio> _list;

        #region Constructors

        public AudioList()
        {
            this._list = new List<Audio>();
        }

        public AudioList(IEnumerable<Audio> enums)
        {
            this._list = new List<Audio>();

            foreach (Audio val in enums)
            {
                this._list.Add(val);
            }
        }

        public AudioList(Int32 val)
        {
            this._list = new List<Audio>(val);
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return this._list.Count; }
            set { }
        }

        public Audio this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion

        #region Methods

        public void Add(Audio obj)
        {
            this._list.Add(obj);
        }

        public void AddRange(IEnumerable<Audio> val)
        {
            foreach (Audio val1 in val)
            {
                _list.Add(val1);
            }
        }

        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }
        public void Clear()
        {
            _list.Clear();
        }

        public AudioList FindAll(Predicate<Audio> predicate)
        {
            AudioList findList = new AudioList();

            findList._list = _list.FindAll(predicate);

            return findList;
        }

        public List<string> Print()
        {
            List<String> s = new List<String>();


            foreach (Audio val in this._list)
            {
                s.Add(val.ToString()!);
            }

            return s;
        }

        public void Sort()
        {
            _list.Sort();
        }

        public void Sort(Comparison<Audio> comparison)
        {
            _list.Sort(comparison);
        }

        public void Sort(System.Collections.Generic.IComparer<Audio>? comparer)
        {
            _list.Sort(comparer);
        }

        public void Sort(int index, int count, System.Collections.Generic.IComparer<Audio>? comparer)
        {
            _list.Sort(index, count, comparer);
        }

        public void SortInt()
        {
            IComparer<Audio> comparer = new IntComparator();
            _list.Sort(comparer);
        }

        public void SortString()
        {
            IComparer<Audio> comparer = new StringComparator();
            _list.Sort(comparer);
        }

        IEnumerator<Audio> IEnumerable<Audio>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }

    #endregion

}