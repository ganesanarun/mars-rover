namespace MarsRover.Rover.Instruction
{
    public readonly struct LeftRotateCommand : InstructionCommand
    {
        public RoverPosition Execute(RoverPosition position)
        {
            var cardinality = position.Cardinality switch
            {
                Cardinality.N => Cardinality.W,
                Cardinality.S => Cardinality.E,
                Cardinality.E => Cardinality.N,
                Cardinality.W => Cardinality.S,
                _ => position.Cardinality
            };
            return position.With(cardinality);
        }
    }
}