using GridDungeonGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            DungeonGenerator dungeonGenerator = new DungeonGenerator();
            Dungeon dungeon = dungeonGenerator.Generate();
            DungeonRenderer.DrawDungeon(dungeon);
            Console.ReadKey();
        }
    }
}
