namespace AlgoritmenVanMike
{
    class Program
    {
        static void Main(string[] args)
        { //GameOfLife game = new GameOfLife();
           //game.RunGame(100); 

           SieveOfEratosthenes sieve = new SieveOfEratosthenes();
           sieve.runSieve(100);

        }
    }
}