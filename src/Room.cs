namespace GridDungeonGenerator
{
    internal enum DoorPosition
    {
        TOP,
        RIGHT,
        DOWN,
        LEFT
    }

    internal class Door
    {
        internal List<Square> Entrances;

        internal Door(Square a, Square b) 
        {
            Entrances = new List<Square> { a, b };
        }
    }

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

        internal List<Door> Doors = new List<Door>();

        private List<DoorPosition> _doorUsed = new List<DoorPosition>
        {
            DoorPosition.TOP, DoorPosition.RIGHT, DoorPosition.DOWN, DoorPosition.LEFT
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
            square.Type = SquareType.Room;
            _squares.Add(square);
        }

        internal void CreateDoors()
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

            while (DoorQuantity > 0)
            {
                int doorType = _rnd.Next(0, 4);

                int doorAX = 0;
                int doorAY = 0;
                int doorBX = 0;
                int doorBY = 0;

                if (doorType == 0 && _doorUsed.Contains(DoorPosition.TOP))
                {
                    _doorUsed.Remove(DoorPosition.TOP);
                    int doorPosition = _rnd.Next(1, Height - 2);

                    doorAY = doorPosition;
                    doorBY = doorPosition + 1;
                }
                else if (doorType == 1 && _doorUsed.Contains(DoorPosition.DOWN))
                {
                    _doorUsed.Remove(DoorPosition.DOWN);
                    int doorPosition = _rnd.Next(1, Height - 2);

                    doorAX = Width - 1;
                    doorBX = Width - 1;

                    doorAY = doorPosition;
                    doorBY = doorPosition + 1;
                }
                else if (doorType == 2 && _doorUsed.Contains(DoorPosition.RIGHT))
                {
                    _doorUsed.Remove(DoorPosition.RIGHT);
                    int doorPosition = _rnd.Next(1, Width - 2);

                    doorAX = doorPosition;
                    doorBX = doorPosition + 1;

                    doorAY = Height - 1;
                    doorBY = Height - 1;
                }
                else
                {
                    _doorUsed.Remove(DoorPosition.LEFT);
                    int doorPosition = _rnd.Next(1, Width - 2);

                    doorAX = doorPosition;
                    doorBX = doorPosition + 1;
                }

                _squaresArray[doorAX, doorAY].IsDoor = true;
                _squaresArray[doorBX, doorBY].IsDoor = true;

                Doors.Add(new Door(_squaresArray[doorAX, doorAY], _squaresArray[doorBX, doorBY]));
                DoorQuantity--;
            }
        }
    }
}
