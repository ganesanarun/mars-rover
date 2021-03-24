using System;

namespace MarsRover.Rover.Instruction
{
    public class RightRotateCommand : InstructionCommand
    {
        public (RoverPosition? position, InvalidCommandError? error) Execute(RoverPosition position)
        {
            var cardinality = position.Cardinality switch
            {
                Cardinality.N => Cardinality.E,
                Cardinality.S => Cardinality.W,
                Cardinality.E => Cardinality.S,
                Cardinality.W => Cardinality.N,
                _ => throw new ArgumentOutOfRangeException()
            };
            return (position.With(cardinality), null);
        }
    }
}