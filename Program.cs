namespace GridDungeonGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Generator");
            Console.WriteLine();

            int roomsNumber = 5;
            int rooms = 0;
            int dungeonSizeX = 30;
            int dungeonSizeY = 30;

            int roomMaxSize = 10;
            int currentRoomMaxSize = 10;
            int roomMinSize = 5;
            int tries = 0;
            int tolerance = 10000;

            Dungeon dungeon = new Dungeon(dungeonSizeX, dungeonSizeY);
            Random rnd = new Random();

            while (rooms < roomsNumber)
            {
                // TODO Reset dungeon here (create a new one)
                if (tolerance >= 100 && currentRoomMaxSize > roomMinSize) 
                {
                    currentRoomMaxSize--;
                }

                int randX = rnd.Next(dungeonSizeX);
                int randY = rnd.Next(dungeonSizeX);

                int randSizeX = rnd.Next(roomMinSize, currentRoomMaxSize);
                int randSizeY = rnd.Next(roomMinSize, currentRoomMaxSize);

                if (dungeon.RoomFits(randX, randY, randSizeX, randSizeY))
                {
                    dungeon.AddRoom(new Room(randX, randY, randSizeX, randSizeY));

                    currentRoomMaxSize = roomMaxSize;
                    tries = 0;

                    rooms++;
                }
                else
                {
                    if (currentRoomMaxSize > roomMinSize)
                        currentRoomMaxSize--;

                    tries++;
                }
            }

            dungeon.ConnectRooms();

            DungeonRenderer.DrawDungeon(dungeon);

            Console.ReadKey();
        }
    }
}