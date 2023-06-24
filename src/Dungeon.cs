using GridDungeonGenerator.Pathfinding;

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
                    if (Grid[originX + posX, originY + posY].Type == SquareType.Room || Grid[originX + posX, originY + posY].Disabled)
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
            room.CreateDoors();
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
                Room endRoom = Rooms[i + 1];

                Door entrance = startRoom.Doors[rnd.Next(startRoom.Doors.Count)];
                Door exit = endRoom.Doors[rnd.Next(endRoom.Doors.Count)];

                List<Node> finalPath = new List<Node>();

                for (int f = 0; f < entrance.Entrances.Count; f++)
                {
                    Node startNode = NodesArray[entrance.Entrances[f].X, entrance.Entrances[f].Y];

                    for (int c = 0; c < exit.Entrances.Count; c++)
                    {
                        Node endNode = NodesArray[exit.Entrances[c].X, exit.Entrances[c].Y];

                        List<Node>? path = pathfinder.GetPath(NodesArray, startNode, endNode);

                        if (path != null)
                            foreach (Node node in path)
                            {
                                finalPath.Add(node);
                            }
                    }
                }

                foreach (Node node in finalPath)
                {
                    Grid[node.Position.X, node.Position.Y].Disabled = true;
                    Grid[node.Position.X, node.Position.Y].Type = SquareType.Room;
                }
            }
        }

        private Node[,] SquareToNodeArray() 
        {
            Node[,] result = new Node[Grid.GetLength(0), Grid.GetLength(1)];
            foreach (Square square in Grid)
            {
                if (square.Type == SquareType.Room && !square.IsDoor) 
                {
                    square.Node.Walkable = false;
                }
                result[square.X, square.Y] = square.Node;
            }
            return result;
        }

        internal List<Square> GetSquareNeighbours(Square square) 
        {
            List<Square> result = new List<Square>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
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
