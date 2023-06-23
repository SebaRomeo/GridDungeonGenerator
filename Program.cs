namespace GridDungeonGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Generator");
            Console.WriteLine();

            int roomsNumber = 2;

            Dungeon dungeon = new Dungeon(25, 25);
            Random rnd = new Random();

            int rooms = 0;

            while (rooms < roomsNumber)
            {
                int randX = rnd.Next(25);
                int randY = rnd.Next(25);

                int randSizeX = rnd.Next(5, 10);
                int randSizeY = rnd.Next(5, 10);

                if (dungeon.RoomFits(randX, randY, randSizeX, randSizeY))
                {
                    dungeon.AddRoom(randX, randY, randSizeX, randSizeY);
                    rooms++;
                }
            }

            //Dungeon.ConnectRooms();

            DungeonRenderer.DrawDungeon(dungeon);

            Console.ReadKey();
        }
    }
}