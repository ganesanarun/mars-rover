namespace MarsRover.UserInteraction
{
    public readonly struct RoverMoveInstruction : Instruction
    {
        public string RoverId { get; }
        public string Instructions { get; }

        public RoverMoveInstruction(string roverId, string instructions)
        {
            RoverId = roverId;
            Instructions = instructions;
        }
    }
}