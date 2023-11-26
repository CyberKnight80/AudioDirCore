namespace AudioDirLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Song song = new Song("No surprises", 228, 852066000, "OK COMPUTER", "Radiohead");
            Podcast podcast = new Podcast("Развитие продукта от 0 до 1", 6395, 1700427600, "PodLodka", 1, 347);
            AudioBook audiobook = new AudioBook("1984", 35438, 1612818000, "George Orwell", "Novel", 18);
            List<Audio> mylibrary = new List<Audio> { song, podcast, audiobook };

            song.About(); podcast.About(); audiobook.About();
        }
    }
}