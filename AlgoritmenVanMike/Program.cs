namespace AlleAlgoritmesVanMike
{
    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife();
            game.RunGame(100); 
        }
    }
}