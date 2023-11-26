namespace AudioDirLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Song song = new Song("No surprises", 228, 852066000, "OK COMPUTER", "Radiohead");
            song.About();
        }
    }
}