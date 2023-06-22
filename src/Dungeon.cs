namespace GridDungeonGenerator
{
    internal class Dungeon
    {
        internal Square[,] grid;

        internal Dungeon(int width, int height)
        {
            grid = new Square[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new Square();
                }
            }
        }

        internal void AddRoom(int originX, int originY, int width, int height)
        {
            bool canBuild = true;

            for (int i = 0; i <= width; i++)
            {
                for (int f = 0; f <= height; f++)
                {
                    if (originX + i < 0 || originX + i > grid.GetLength(0)
                        || originY + f < 0 || originY + f > grid.GetLength(1))
                        {
                            canBuild = false;
                            break;
                        }
                }

            }

            if (!canBuild)
            {
                Console.WriteLine("Cant build room, there is no space");
                return;
            }

            for (int i = 0; i <= width; i++)
            {
                for (int f = 0; f <= height; f++)
                {
                    grid[originX + i, originY + f].roomPart = true;
                }
            }
        }
    }
}
