using System;

namespace MarsRover.Rover.Instruction
{
    public class MoveCommand : InstructionCommand
    {
        private readonly Boundary boundary;

        public MoveCommand(Boundary boundary)
        {
            this.boundary = boundary;
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

            return boundary.IsAllowedPosition(nextPossiblePosition)
                ? (nextPossiblePosition, null)
                : (null, new InvalidCommandError());
        }
    }
}