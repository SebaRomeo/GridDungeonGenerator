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

        internal bool RoomFits(int originX, int originY, int width, int height) 
        {
            int x = originX + width;
            int y = originY + height;

            if (x >= grid.GetLength(0) || y >= grid.GetLength(1))
                return false;

            return true;
        }

        internal void AddRoom(int originX, int originY, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int f = 0; f < height; f++)
                {
                    grid[originX + i, originY + f].roomPart = true;
                }
            }
        }
    }
}
