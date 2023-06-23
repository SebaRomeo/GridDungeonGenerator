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
            int dungeonSizeX = 50;
            int dungeonSizeY = 50;

            Dungeon dungeon = new Dungeon(dungeonSizeX, dungeonSizeY);
            Random rnd = new Random();

            while (rooms < roomsNumber)
            {
                int randX = rnd.Next(dungeonSizeX);
                int randY = rnd.Next(dungeonSizeX);

                int randSizeX = rnd.Next(5, 10);
                int randSizeY = rnd.Next(5, 10);

                if (dungeon.RoomFits(randX, randY, randSizeX, randSizeY))
                {
                    dungeon.AddRoom(new Room(randX, randY, randSizeX, randSizeY));
                    rooms++;
                }
            }

            dungeon.ConnectRooms();

            DungeonRenderer.DrawDungeon(dungeon);

            Console.ReadKey();
        }
    }
}