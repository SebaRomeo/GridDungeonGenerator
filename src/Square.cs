namespace GridDungeonGenerator
{
    internal class Square
    {
        internal bool RoomPart = false;
        internal bool IsPath = false;
        internal string RoomPartType = "";
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
