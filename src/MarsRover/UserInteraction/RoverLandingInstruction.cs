using MarsRover.Rover;

namespace MarsRover.UserInteraction
{
    public readonly struct RoverLandingInstruction : Instruction
    {
        public string RoverId { get; }
        public int X { get; }
        public int Y { get; }
        public Cardinality Cardinality { get; }

        public RoverLandingInstruction(string roverId, int x, int y, Cardinality cardinality)
        {
            RoverId = roverId;
            X = x;
            Y = y;
            Cardinality = cardinality;
        }
    }
}