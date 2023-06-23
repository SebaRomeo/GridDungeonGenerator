namespace GridDungeonGenerator
{
    internal class Dungeon
    {
        internal Square[,] grid;
        internal List<Room> Rooms;

        internal Dungeon(int width, int height)
        {
            grid = new Square[width, height];
            Rooms = new List<Room>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new Square(x, y);
                }
            }
        }

        internal bool RoomFits(int originX, int originY, int width, int height)
        {
            int x = originX + width;
            int y = originY + height;

            if (x >= grid.GetLength(0) || y >= grid.GetLength(1) || originX <= 1 || originY <= 1
                || originX + width + 2 >= grid.GetLength(0) || originY + height + 2 >= grid.GetLength(1))
                return false;

            for (int posX = 0; posX < width; posX++)
            {
                for (int posY = 0; posY < height; posY++)
                {
                    if (grid[originX + posX, originY + posY].RoomPart)
                        return false;
                }
            }

            return true;
        }

        internal void AddRoom(Room room)
        {
            for (int i = 0; i < room.Width; i++)
            {
                for (int f = 0; f < room.Height; f++)
                {
                    room.AddSquare(grid[room.OriginX + i, room.OriginY + f]);
                }
            }
            room.AssigneSquareType();
            Rooms.Add(room);

            // Disable neighbours to avoid rooms without separation
        }
    }
}
