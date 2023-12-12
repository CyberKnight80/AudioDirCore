namespace AudioDirCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            //Song song = new Song("No surprises", 228, 852066000, "OK COMPUTER", "Radiohead");
            //Podcast podcast = new Podcast("Развитие продукта от 0 до 1", 6395, 1700427600, "PodLodka", 1, 347);
            //AudioBook audiobook = new AudioBook("1984", 35438, 1612818000, "George Orwell", "Novel", 18);
            //List<Audio> mylibrary = new List<Audio> { song, podcast, audiobook };

            //foreach (Audio a in mylibrary) { a.About(); };

            //Console.WriteLine("\nSaving data . . .\n");

            //Loader.SaveObjects("spotify.txt", mylibrary);
            //List<Audio> mylibrary_saved = Loader.LoadObjects("spotify.txt");

            //foreach (Audio a in mylibrary_saved) { a.About(); };
            //AudioList audioList = new AudioList();
            //audioList.Randomize();
            //string[] data = audioList.Print();
            //foreach (string d in data) Console.WriteLine(d);

        }
    }
}