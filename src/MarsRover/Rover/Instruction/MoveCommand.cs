using System;

namespace MarsRover.Rover.Instruction
{
    public class MoveCommand : InstructionCommand
    {
        public Boundary Boundary { get; }

        public MoveCommand(Boundary boundary)
        {
            Boundary = boundary;
        }

        public (RoverPosition? position, InvalidCommandError? error) Execute(RoverPosition position)
        {
            var nextPossiblePosition = position.Cardinality switch
            {
                Cardinality.N => position.Up(),
                Cardinality.S => position.Down(),
                Cardinality.E => position.Right(),
                Cardinality.W => position.Left(),
                _ => throw new ArgumentOutOfRangeException()
            };

            return Boundary.IsAllowedPosition(nextPossiblePosition)
                ? (nextPossiblePosition, null)
                : (null, new InvalidCommandError());
        }
    }
}