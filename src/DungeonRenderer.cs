namespace GridDungeonGenerator
{
    internal static class DungeonRenderer
    {
        public static void DrawDungeon(Dungeon dungeon) 
        {
            for (int x = 0; x < dungeon.grid.GetLength(0); x++)
            {
                for (int y = 0; y < dungeon.grid.GetLength(1); y++)
                {
                    if (dungeon.grid[x, y].roomPart)
                        Console.Write('#');
                    else
                        Console.Write('·');
                        
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
