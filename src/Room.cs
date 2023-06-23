namespace GridDungeonGenerator
{
    internal class Room
    {

        internal int OriginX;
        internal int OriginY;
        internal int Width;
        internal int Height;
        internal int DoorQuantity;

        private Square[,] _squaresArray;
        private List<Square> _squares;
        private Random _rnd;

        private List<string> _doorUsed = new List<string>
        {
            "TOP", "RIGHT", "DOWN", "LEFT"
        };

        internal Room(int originX, int originY, int width, int height)
        {
            _rnd = new Random();
            DoorQuantity = _rnd.Next(1, 5);

            OriginX = originX;
            OriginY = originY;
            Width = width;
            Height = height;

            _squares = new List<Square>();
            _squaresArray = new Square[Width, Height];
        }

        internal void AddSquare(Square square)
        {
            square.RoomPart = true;
            _squares.Add(square);
        }

        internal void AssigneSquareType()
        {
            int squareIndex = 0;
            for (int x = 0; x < Width; x++)
            {
                for (int i = 0; i < Height; i++)
                {
                    _squares[squareIndex].RoomX = x;
                    _squares[squareIndex].RoomY = i;
                    _squaresArray[x, i] = _squares[squareIndex];
                    squareIndex++;
                }
            }

            for (int i = 0; i < _squares.Count; i++)
            {
                if (DoorQuantity > 0)
                {
                    int doorType = _rnd.Next(0, 4);
                    /*
                        0 = TOP
                        1 = DOWN
                        2 = RIGHT
                        3 = LEFT
                    */

                    if (doorType == 0 && _doorUsed.Contains("TOP"))
                    {
                        int doorPosition = _rnd.Next(1, Height - 2);
                        _squaresArray[0, doorPosition].RoomPartType = "door";
                        _squaresArray[0, doorPosition + 1].RoomPartType = "door";
                        _doorUsed.Remove("TOP");
                        DoorQuantity--;
                    }
                    else if (doorType == 1 && _doorUsed.Contains("DOWN"))
                    {
                        int doorPosition = _rnd.Next(1, Height - 2);
                        _squaresArray[Width - 1, doorPosition].RoomPartType = "door";
                        _squaresArray[Width - 1, doorPosition + 1].RoomPartType = "door";
                        _doorUsed.Remove("DOWN");                       
                        DoorQuantity--;
                    }
                    else if (doorType == 2 && _doorUsed.Contains("RIGHT"))
                    {
                        int doorPosition = _rnd.Next(1, Width - 2);
                        _squaresArray[doorPosition, Height - 1].RoomPartType = "door";
                        _squaresArray[doorPosition + 1, Height - 1].RoomPartType = "door";
                        _doorUsed.Remove("RIGHT");
                        DoorQuantity--;
                    }
                    else if (doorType == 3 && _doorUsed.Contains("LEFT"))
                    {
                        int doorPosition = _rnd.Next(1, Width - 2);
                        _squaresArray[doorPosition, 0].RoomPartType = "door";
                        _squaresArray[doorPosition + 1, 0].RoomPartType = "door";
                        _doorUsed.Remove("LEFT");
                        DoorQuantity--;
                    }
                }
            }
        }
    }
}
