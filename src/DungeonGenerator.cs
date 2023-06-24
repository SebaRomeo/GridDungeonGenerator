namespace GridDungeonGenerator
{
    internal class DungeonGenerator
    {
        private int _roomsQuanity = 5;
        private int _roomsCreated = 0;
        private int _roomMinSize = 5;
        private int _roomMaxSize = 10, _currentRoomMaxSize = 10;

        private int _dungeonSizeX = 30;
        private int _dungeonSizeY = 30;

        private int _attemps = 0;

        public Dungeon Generate()
        {
            Console.WriteLine("Dungeon Generator");
            Console.WriteLine();

            Dungeon dungeon = new Dungeon(_dungeonSizeX, _dungeonSizeY);
            Random rnd = new Random();

            while (_roomsCreated < _roomsQuanity)
            {
                if (_attemps >= 100000)
                {
                    dungeon = new Dungeon(_dungeonSizeX, _dungeonSizeY);
                    _attemps = 0;
                    _currentRoomMaxSize = _roomMaxSize;
                }

                int randX = rnd.Next(_dungeonSizeX);
                int randY = rnd.Next(_dungeonSizeY);

                int randSizeX = rnd.Next(_roomMinSize, _currentRoomMaxSize);
                int randSizeY = rnd.Next(_roomMinSize, _currentRoomMaxSize);

                if (dungeon.RoomFits(randX, randY, randSizeX, randSizeY))
                {
                    dungeon.AddRoom(new Room(randX, randY, randSizeX, randSizeY));

                    _currentRoomMaxSize = _roomMaxSize;
                    _attemps = 0;

                    _roomsCreated++;
                }
                else
                {
                    if (_currentRoomMaxSize > _roomMinSize)
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
                    if (neighbour.RoomPart)
                    {
                        isNearRoom = true;
                        break;
                    }
                }
                square.IsWall = isNearRoom;
            }

            return dungeon;
        }
    }
}
