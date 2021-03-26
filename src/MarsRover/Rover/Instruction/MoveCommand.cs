namespace MarsRover.Rover.Instruction
{
    public readonly struct MoveCommand : InstructionCommand
    {
        public RoverPosition Execute(RoverPosition position)
        {
            return position.Cardinality switch
            {
                Cardinality.N => position.Up(),
                Cardinality.S => position.Down(),
                Cardinality.E => position.Right(),
                Cardinality.W => position.Left(),
                _ => position
            };
        }
    }
}