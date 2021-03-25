using System;

namespace MarsRover.Rover.Instruction
{
    public readonly struct LeftRotateCommand : InstructionCommand
    {
        public (RoverPosition? position, InvalidCommandError? error) Execute(RoverPosition position)
        {
            var cardinality = position.Cardinality switch
            {
                Cardinality.N => Cardinality.W,
                Cardinality.S => Cardinality.E,
                Cardinality.E => Cardinality.N,
                Cardinality.W => Cardinality.S,
                _ => throw new ArgumentOutOfRangeException()
            };
            return (position.With(cardinality), null);
        }
    }
}