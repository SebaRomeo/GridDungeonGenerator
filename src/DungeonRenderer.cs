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
                    if (dungeon.grid[x, y].RoomPart)
                    {
                        if (dungeon.grid[x, y].RoomPartType == "door")
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write('#');
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write('·');
                    }

                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
