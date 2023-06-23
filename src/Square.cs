namespace GridDungeonGenerator
{
    internal class Square
    {
        internal bool RoomPart = false;
        internal string RoomPartType = "";
        internal int X;
        internal int Y;

        internal int RoomX;
        internal int RoomY;

        internal Square(int x, int y)
        {
            X = x; 
            Y = y;
        }
    }
}
