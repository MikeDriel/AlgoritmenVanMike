namespace AlleAlgoritmesVanMike
{
    public class GameOfLife
    {
        int huidigeIteratie = 0;
        public int[,] grid = new int[10, 10];

        public int[][] cellsAroundCell = new int[][] {
            new int[] { -1, -1 }, new int[] { -1, 0 }, new int[] { -1, 1 },
            new int[] { 0, -1 },                  new int[] { 0, 1 },
            new int[] { 1, -1 }, new int[] { 1, 0 }, new int[] { 1, 1 }
        };
        public GameOfLife()
        {
            GenerateGrid();
        }

        public void RunGame(int iterations)
        {
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                int[,] newGrid = new int[grid.GetLength(0), grid.GetLength(1)];

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        int aliveNeighbors = CheckHowManyCellsAreAliveAroundMe(i, j);

                        if (grid[i, j] == 1)
                        {
                            if (aliveNeighbors < 2 || aliveNeighbors > 3)
                            {
                                newGrid[i, j] = 0; // Cell dies
                            }
                            else
                            {
                                newGrid[i, j] = 1; // Cell lives
                            }
                        }
                        else
                        {
                            if (aliveNeighbors == 3)
                            {
                                newGrid[i, j] = 1; // Cell becomes alive
                            }
                        }
                    }
                }

                grid = newGrid;
                PrintGrid();
                huidigeIteratie++;
                Thread.Sleep(1000);
            }
        }

        // Self explanatory
        public int CheckHowManyCellsAreAliveAroundMe(int x, int y)
        {
            int aliveCount = 0;
            foreach (int[] offset in cellsAroundCell)
            {
                int newX = x + offset[0];
                int newY = y + offset[1];

                if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                {
                    aliveCount += grid[newX, newY] == 1 ? 1 : 0;
                }
            }
            return aliveCount;
        }


        // Generates le grid
        public void GenerateGrid()
        {
            Random rnd = new Random();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = rnd.Next(0, 2);
                }
            }
        }

        public void PrintGrid()
        {
            Console.WriteLine($"Iteration {huidigeIteratie}:");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                // converts the 1 and 0's to square things
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] == 1 ? "■ " : "□ ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
