using GridDungeonGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dungeon Generator");
        Console.WriteLine("Press any key to generate or press Q to exit");
        while (true)
        {
            DungeonGenerator dungeonGenerator = new DungeonGenerator();
            DungeonArgsBuilder dungeonArgs = new DungeonArgsBuilder();

            dungeonArgs.DungeonSizeX(30).DungeonSizeY(30).RoomMinSize(5).RoomMaxSize(10).RoomsQuantity(5);

            Dungeon dungeon = dungeonGenerator.Generate(dungeonArgs.Build);
            DungeonRenderer.DrawDungeon(dungeon);

            if (Console.ReadKey().Key == ConsoleKey.Q)
                break;
        }
    }
}
