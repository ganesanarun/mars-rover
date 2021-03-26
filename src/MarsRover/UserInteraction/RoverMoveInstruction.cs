namespace MarsRover.UserInteraction
{
    public readonly struct RoverMoveInstruction : Instruction
    {
        public string RoverId { get; }
        public string Instruction { get; }

        public RoverMoveInstruction(string roverId, string instruction)
        {
            RoverId = roverId;
            Instruction = instruction;
        }
    }
}