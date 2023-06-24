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
            Dungeon dungeon = dungeonGenerator.Generate(new DungeonArgsBuilder().Build);
            DungeonRenderer.DrawDungeon(dungeon);

            if (Console.ReadKey().Key == ConsoleKey.Q)
                break;
        }
    }
}
