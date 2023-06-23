namespace GridDungeonGenerator
{
    internal class Room
    {
        private List<Square> Squares;

        internal int OriginX;
        internal int OriginY;
        internal int Width;
        internal int Height;

        internal int DoorQuantity = 2;

        List<string> DoorUsed = new List<string>
        {
        "TOP", "RIGHT", "DOWN", "LEFT"
        };

        internal Square[,] squaresArray;

        internal Room(int originX, int originY, int width, int height)
        {
            OriginX = originX;
            OriginY = originY;
            Width = width;
            Height = height;

            Squares = new List<Square>();
            squaresArray = new Square[Width, Height];
        }

        internal void AddSquare(Square square)
        {
            square.RoomPart = true;
            Squares.Add(square);
        }

        internal void AssigneSquareType()
        {
            Random rnd = new Random();
            int squareIndex = 0;
            for (int x = 0; x < Width; x++)
            {
                for (int i = 0; i < Height; i++)
                {
                    Squares[squareIndex].RoomX = x;
                    Squares[squareIndex].RoomY = i;
                    squaresArray[x, i] = Squares[squareIndex];
                    squareIndex++;
                }
            }

            foreach (Square square in Squares)
            {
                if (DoorQuantity > 0)
                {
                    int doorType = rnd.Next(0, 4);
                    /*
                        0 = TOP
                        1 = DOWN
                        2 = RIGHT
                        3 = LEFT
                    */

                    if (doorType == 0 && DoorUsed.Contains("TOP"))
                    {
                        int doorPosition = rnd.Next(1, Height - 2);
                        squaresArray[0, doorPosition].RoomPartType = "door";
                        squaresArray[0, doorPosition + 1].RoomPartType = "door";
                        DoorUsed.Remove("TOP");
                    }
                    else if (doorType == 1 && DoorUsed.Contains("DOWN"))
                    {
                        int doorPosition = rnd.Next(1, Height - 2);
                        squaresArray[Width - 1, doorPosition].RoomPartType = "door";
                        squaresArray[Width - 1, doorPosition + 1].RoomPartType = "door";
                        DoorUsed.Remove("DOWN");
                    }
                    else if (doorType == 2 && DoorUsed.Contains("RIGHT"))
                    {
                        int doorPosition = rnd.Next(1, Width - 2);
                        squaresArray[doorPosition, Height - 1].RoomPartType = "door";
                        squaresArray[doorPosition + 1, Height - 1].RoomPartType = "door";
                        DoorUsed.Remove("RIGHT");
                    }
                    else if (doorType == 3 && DoorUsed.Contains("LEFT"))
                    {
                        int doorPosition = rnd.Next(1, Width - 2);
                        squaresArray[doorPosition, 0].RoomPartType = "door";
                        squaresArray[doorPosition + 1, 0].RoomPartType = "door";
                        DoorUsed.Remove("LEFT");
                    }
                }
            }
        }
    }
}
