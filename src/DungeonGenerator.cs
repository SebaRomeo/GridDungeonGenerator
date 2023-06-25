namespace GridDungeonGenerator
{
    public class DungeonGenerator
    {
        private int _roomsCreated = 0;
        private int _currentRoomMaxSize = 10;
        private int _attemps = 0;

        public Dungeon Generate(DungeonArgs args)
        {
            Dungeon dungeon = new Dungeon(args.DungeonSizeX, args.DungeonSizeY);
            Random rnd = new Random();

            while (_roomsCreated < args.RoomsQuantity)
            {
                if (_attemps >= 100000)
                {
                    dungeon = new Dungeon(args.DungeonSizeX, args.DungeonSizeY);
                    _attemps = 0;
                    _currentRoomMaxSize = args.RoomMaxSize;
                }

                int randX = rnd.Next(args.DungeonSizeX);
                int randY = rnd.Next(args.DungeonSizeY);

                int randSizeX = rnd.Next(args.RoomMinSize, _currentRoomMaxSize);
                int randSizeY = rnd.Next(args.RoomMinSize, _currentRoomMaxSize);

                if (dungeon.RoomFits(randX, randY, randSizeX, randSizeY))
                {
                    dungeon.AddRoom(new Room(randX, randY, randSizeX, randSizeY));

                    _currentRoomMaxSize = args.RoomMaxSize;
                    _attemps = 0;

                    _roomsCreated++;
                }
                else
                {
                    if (_currentRoomMaxSize > args.RoomMinSize)
                        _currentRoomMaxSize--;

                    _attemps++;
                }
            }

            dungeon.ConnectRooms();

            foreach (Square square in dungeon.Grid)
            {
                List<Square> neighbours = dungeon.GetSquareNeighbours(square);

                bool isNearRoom = false;

                foreach (Square neighbour in neighbours)
                {
                    if (neighbour.Type == SquareType.Room)
                    {
                        isNearRoom = true;
                        break;
                    }
                }

                if (isNearRoom && square.Type == SquareType.Empty)
                    square.Type = SquareType.Wall;
            }
            return dungeon;
        }
    }
}
