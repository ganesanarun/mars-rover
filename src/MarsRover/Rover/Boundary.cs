namespace MarsRover.Rover
{
    public readonly struct Boundary
    {
        private readonly int minimumX;
        private readonly int maximumX;
        private readonly int minimumY;
        private readonly int maximumY;

        public Boundary(int minimumX, int maximumX, int minimumY, int maximumY)
        {
            this.minimumX = minimumX;
            this.maximumX = maximumX;
            this.minimumY = minimumY;
            this.maximumY = maximumY;
        }

        public bool IsAllowedPosition(RoverPosition position)
        {
            return position.X >= minimumX && position.X <= maximumX && position.Y >= minimumY && position.Y <= maximumY;
        }

        public static Boundary WithMaximumXAndY(int maximumX, int maximumY)
        {
            return new(0, maximumX, 0, maximumY);
        }
    }
}