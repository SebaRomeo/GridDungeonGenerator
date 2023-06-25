namespace GridDungeonGenerator
{
    public class DungeonArgs
    {
        internal int RoomsQuantity = 2;
        internal int RoomMinSize = 3;
        internal int RoomMaxSize = 3;

        internal int DungeonSizeX = 30;
        internal int DungeonSizeY = 30;

        internal DungeonArgs() { }
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
            if (quantity < 1)
                throw new Exception("Rooms quantity must be bigger than 1");

            Build.RoomsQuantity = quantity;
            return this;
        }

        public DungeonArgsBuilder RoomMinSize(int min)
        {
            if (min < 3)
                throw new Exception("Minimum room size is 3");

            Build.RoomMinSize = min;
            return this;
        }

        public DungeonArgsBuilder RoomMaxSize(int max)
        {
            if (max < 3)
                throw new Exception("Maximum room size is 3");

            Build.RoomMaxSize = max;
            return this;
        }

        public DungeonArgsBuilder DungeonSizeX(int sizeX)
        {
            if (sizeX < 15)
                throw new Exception("Dungeon size X cannot be smaller tan 15");

            Build.DungeonSizeX = sizeX;
            return this;
        }

        public DungeonArgsBuilder DungeonSizeY(int sizeY)
        {
            if (sizeY < 15)
                throw new Exception("Dungeon size Y cannot be smaller tan 15");

            Build.DungeonSizeY = sizeY;
            return this;
        }
    }
}
