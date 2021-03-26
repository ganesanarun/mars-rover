namespace MarsRover.UserInteraction
{
    public readonly struct PlateauInstruction : Instruction
    {
        public int MaximumX { get; }
        public int MaximumY { get; }

        public PlateauInstruction(int maximumX, int maximumY)
        {
            MaximumX = maximumX;
            MaximumY = maximumY;
        }
    }
}