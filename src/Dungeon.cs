namespace GridDungeonGenerator
{
    internal class Dungeon
    {
        internal Square[,] Grid;
        internal List<Room> Rooms;

        internal Dungeon(int width, int height)
        {
            Grid = new Square[width, height];
            Rooms = new List<Room>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Grid[x, y] = new Square(x, y);
                }
            }
        }

        internal bool RoomFits(int originX, int originY, int width, int height)
        {
            int x = originX + width;
            int y = originY + height;

            if (x >= Grid.GetLength(0) || y >= Grid.GetLength(1) || originX <= 1 || originY <= 1
                || originX + width + 2 >= Grid.GetLength(0) || originY + height + 2 >= Grid.GetLength(1))
                return false;

            for (int posX = 0; posX < width; posX++)
            {
                for (int posY = 0; posY < height; posY++)
                {
                    if (Grid[originX + posX, originY + posY].RoomPart || Grid[originX + posX, originY + posY].Disabled)
                        return false;
                }
            }

            return true;
        }

        internal void AddRoom(Room room)
        {
            for (int i = 0; i < room.Width; i++)
            {
                for (int f = 0; f < room.Height; f++)
                {
                    room.AddSquare(Grid[room.OriginX + i, room.OriginY + f]);
                    List<Square> squareNeighbours = GetSquareNeighbours(Grid[room.OriginX + i, room.OriginY + f]);
                    foreach (Square square in squareNeighbours)
                    {
                        square.Disabled = true;
                    }
                }
            }
            room.AssigneSquareType();
            Rooms.Add(room);
        }

        internal void ConnectRooms()
        {
            Pathfinder pathfinder = new Pathfinder();
            Node[,] NodesArray = SquareToNodeArray();
            Random rnd = new Random();

            for (int i = 0; i < Rooms.Count - 1; i++)
            {
                Room startRoom = Rooms[i];
                Room endRoom = Rooms[i+1];

                Door doorsA = startRoom.Doors[rnd.Next(startRoom.Doors.Count)];
                Door doorsB = endRoom.Doors[rnd.Next(endRoom.Doors.Count)];

                Node startNode = NodesArray[doorsA.EntranceA.X, doorsA.EntranceA.Y];
                Node endNode = NodesArray[doorsB.EntranceA.X, doorsB.EntranceA.Y];

                List<Node> path = pathfinder.GetPath(NodesArray, startNode, endNode);

                foreach (Node node in path)
                {
                    Grid[node.Position.X, node.Position.Y].Disabled = true;
                    Grid[node.Position.X, node.Position.Y].IsPath = true;
                }

                Node startNode2 = NodesArray[doorsA.EntranceB.X, doorsA.EntranceB.Y];
                Node endNode2 = NodesArray[doorsB.EntranceB.X, doorsB.EntranceB.Y];

                List<Node> path2 = pathfinder.GetPath(NodesArray, startNode2, endNode2);

                foreach (Node node in path2)
                {
                    Grid[node.Position.X, node.Position.Y].Disabled = true;
                    Grid[node.Position.X, node.Position.Y].IsPath = true;
                }
            }
        }

        private Node[,] SquareToNodeArray() 
        {
            Node[,] result = new Node[Grid.GetLength(0), Grid.GetLength(1)];
            foreach (Square square in Grid)
            {
                if (square.RoomPart && square.RoomPartType != "door") 
                {
                    square.Node.Walkable = false;
                }

                result[square.X, square.Y] = square.Node;
            }
            return result;
        }

        private List<Square> GetSquareNeighbours(Square square) 
        {
            List<Square> result = new List<Square>();

            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = square.X + x;
                    int checkY = square.Y + y;

                    if (checkX >= 0 && checkX < Grid.GetLength(0) && checkY >= 0 && checkY < Grid.GetLength(1))
                        result.Add(Grid[checkX, checkY]);
                }
            }
            return result;
        }
    }
}
