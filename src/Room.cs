namespace GridDungeonGenerator
{
    internal class Room
    {
        int X;
        int Y;
        Dungeon dungeon;

        internal Room(int originX, int originY, Dungeon dungeon)
        {
            X = originX;
            Y = originY;
            this.dungeon = dungeon;
        }

        internal void BuildRoom() 
        {
            
        }
    }
}
