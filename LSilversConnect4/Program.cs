namespace LSilversConnect4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Logan's Connect 4 Game";
            Game game = new Game();
            game.Play();
        }
    }
}
