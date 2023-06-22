namespace GridDungeonGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Generator");
            Console.WriteLine();

            int roomsNumber = 1;

            Dungeon dungeon = new Dungeon(25, 25);

            for (int i = 0; i < roomsNumber; i++)
            {
                dungeon.AddRoom(1, 1, 5, 5);
            }

            //Dungeon.ConnectRooms();

            DungeonRenderer.DrawDungeon(dungeon);

            Console.ReadKey();
        }
    }
}