namespace GridDungeonGenerator.Pathfinding
{
    internal class Node : IHeapItem<Node>
    {
        public int HeapIndex { get { return heapIndex; } set { heapIndex = value; } }
        internal int GCost;
        internal int HCost;
        internal int FCost { get { return GCost + HCost; } }
        internal bool Walkable { get; set; }
        internal Node parent { get; set; }
        internal Coordinate Position { get; private set; }
        private int heapIndex;

        internal Node(Coordinate position, bool walkable)
        {
            Position = position;
            Walkable = walkable;
        }

        public int CompareTo(Node other)
        {
            int compare = FCost.CompareTo(other.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo(other.HCost);
            }
            return -compare;
        }
    }
}
