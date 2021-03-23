namespace MarsRover.Rover
{
    public readonly struct RoverPosition
    {
        public int X { get; }

        public int Y { get; }

        public Cardinality Cardinality { get; }
        

        public RoverPosition(int x, int y, Cardinality cardinality)
        {
            X = x;
            Y = y;
            Cardinality = cardinality;
        }

        public RoverPosition Up()
        {
            return new(X, Y + 1, Cardinality);
        }

        public RoverPosition Right()
        {
            return new(X + 1, Y, Cardinality);
        }

        public RoverPosition Down()
        {
            return new(X, Y - 1, Cardinality);
        }

        public RoverPosition Left()
        {
            return new(X - 1, Y, Cardinality);
        }
    }
}