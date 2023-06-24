namespace GridDungeonGenerator
{
    public class DungeonArgs
    {
        internal int RoomsQuantity = 5;
        internal int RoomMinSize = 5;
        internal int RoomMaxSize = 10;

        internal int DungeonSizeX = 30;
        internal int DungeonSizeY = 30;

        internal DungeonArgs() 
        { 

        }
    }

    public class DungeonArgsBuilder 
    {
        public DungeonArgs Build { get; private set; }

        public DungeonArgsBuilder() 
        {
            Build = new DungeonArgs();
        }

        public DungeonArgsBuilder RoomsQuantity(int quantity) 
        {
            Build.RoomsQuantity = quantity;
            return this;
        }

        public DungeonArgsBuilder RoomMinSize(int min)
        {
            Build.RoomMinSize = min;
            return this;
        }

        public DungeonArgsBuilder RoomMaxSize(int max)
        {
            Build.RoomMaxSize = max;
            return this;
        }

        public DungeonArgsBuilder DungeonSizeX(int sizeX)
        {
            Build.DungeonSizeX = sizeX;
            return this;
        }

        public DungeonArgsBuilder DungeonSizeY(int sizeY)
        {
            Build.DungeonSizeY = sizeY;
            return this;
        }
    }
}
