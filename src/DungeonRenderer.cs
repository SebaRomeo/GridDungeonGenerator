namespace GridDungeonGenerator
{
    internal static class DungeonRenderer
    {
        public static void DrawDungeon(Dungeon dungeon) 
        {
            for (int x = 0; x < dungeon.Grid.GetLength(0); x++)
            {
                for (int y = 0; y < dungeon.Grid.GetLength(1); y++)
                {
                    Console.ResetColor();
                    if (dungeon.Grid[x, y].RoomPart)
                    {
                        if (dungeon.Grid[x, y].RoomPartType == "door")
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write('#');
                    }
                    else if (dungeon.Grid[x, y].Disabled) 
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('·');
                    }

                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
