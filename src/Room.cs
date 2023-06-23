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
                    if (square.RoomY > 0 && square.RoomY + 1 <= Height) 
                    {
                        squaresArray[square.RoomX, square.RoomY].RoomPartType = "door";
                        DoorQuantity--;
                    }
                }
            }
        }
    }
}
