using System;

namespace MarsRover.Rover.Instruction
{
    public readonly struct RightRotateCommand : InstructionCommand
    {
        public RoverPosition Execute(RoverPosition position)
        {
            var cardinality = position.Cardinality switch
            {
                Cardinality.N => Cardinality.E,
                Cardinality.S => Cardinality.W,
                Cardinality.E => Cardinality.S,
                Cardinality.W => Cardinality.N,
                _ => position.Cardinality
            };
            return position.With(cardinality);
        }
    }
}