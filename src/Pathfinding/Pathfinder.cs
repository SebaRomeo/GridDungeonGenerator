internal class Pathfinder
{
    internal List<Node>? GetPath(Node[,] grid, Node startRoom, Node endRoom)
    {
        Heap<Node> openSet = new Heap<Node>(grid.GetLength(0) * grid.GetLength(1));
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startRoom);

        while (openSet.Count > 0)
        {
            Node currentRoom = openSet.RemoveFirst();

            closedSet.Add(currentRoom);

            if (currentRoom == endRoom)
            {
                return retracePath(startRoom, endRoom);
            }

            foreach (Node neighbour in GetNeighbours(grid, currentRoom))
            {
                if (!neighbour.Walkable || closedSet.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentRoom.GCost + getDistance(currentRoom, neighbour);
                if (newMovementCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
                {
                    neighbour.GCost = newMovementCostToNeighbour;
                    neighbour.HCost = getDistance(neighbour, endRoom);
                    neighbour.parent = currentRoom;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
        return null;
    }

    private int getDistance(Node nodeA, Node nodeB)
    {
        int distanceX = Math.Abs(nodeA.Position.X - nodeB.Position.X);
        int distanceY = Math.Abs(nodeA.Position.Y - nodeB.Position.Y);

        if (distanceX > distanceY)
            return 14 * distanceY + 10 * (distanceX - distanceY);
        return 14 * distanceX + 10 * (distanceY - distanceX); ;
    }

    private List<Node> retracePath(Node startNode, Node targetRoom)
    {
        List<Node> path = new List<Node>();
        Node currentNode = targetRoom;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }

    private List<Node> GetNeighbours(Node[,] grid, Node node)
    {
        List<Node> neighbours = new List<Node>();            

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.Position.X + x;
                int checkY = node.Position.Y + y;

                if (checkX >= 0 && checkX < grid.GetLength(0) && checkY >= 0 && checkY < grid.GetLength(1) && (checkX == node.Position.X || checkY == node.Position.Y))
                    neighbours.Add(grid[checkX, checkY]);
            }
        }
        return neighbours;
    }
}

