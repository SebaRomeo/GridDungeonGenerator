namespace GridDungeonGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonGenerator dungeonGenerator = new DungeonGenerator();
            Dungeon dungeon = dungeonGenerator.Generate();
            DungeonRenderer.DrawDungeon(dungeon);
            Console.ReadKey();
        }
    }
}