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
                    if (grid[originX + posX, originY + posY].RoomPart || grid[originX + posX, originY + posY].Disabled)
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
                    List<Square> squareNeighbours = GetSquareNeighbours(grid[room.OriginX + i, room.OriginY + f]);
                    foreach (Square square in squareNeighbours)
                    {
                        square.Disabled = true;
                    }
                }
            }
            room.AssigneSquareType();
            Rooms.Add(room);
        }

        private List<Square> GetSquareNeighbours(Square square) 
        {
            List<Square> result = new List<Square>();

            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = square.X + x;
                    int checkY = square.Y + y;

                    if (checkX >= 0 && checkX < grid.GetLength(0) && checkY >= 0 && checkY < grid.GetLength(1))
                        result.Add(grid[checkX, checkY]);
                }
            }
            return result;
        }
    }
}
