using GridDungeonGenerator.Pathfinding;

namespace GridDungeonGenerator
{
    public enum SquareType
    {
        Empty,
        Room,
        Wall
    }

    public class Square
    {
        public SquareType Type = SquareType.Empty;
        internal bool IsDoor;
        internal int X;
        internal int Y;

        internal int RoomX;
        internal int RoomY;

        internal bool Disabled = false;

        internal Node Node;

        internal Square(int x, int y)
        {
            X = x; 
            Y = y;

            Node = new Node(new Coordinate(x, y), true);
        }
    }
}
