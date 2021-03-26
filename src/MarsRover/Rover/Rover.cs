using System.Collections.Generic;
using MarsRover.Rover.Instruction;

namespace MarsRover.Rover
{
    public class Rover
    {
        private readonly InstructionProcessor processor;

        private Boundary? currentBoundary;

        public Rover(string id, RoverPosition currentPosition, InstructionProcessor processor)
        {
            this.processor = processor;
            Id = id;
            CurrentPosition = currentPosition;
        }

        public string Id { get; }

        public RoverPosition CurrentPosition { get; private set; }

        public InvalidCommandError? FollowThe(IEnumerable<InstructionCommand> instructions)
        {
            var position = processor.Process(CurrentPosition, instructions);
            if (currentBoundary == null)
            {
                CurrentPosition = position;
                return null;
            }

            var yes = currentBoundary.Value.CanIMoveToThis(position);

            if (!yes)
            {
                return new InvalidCommandError();
            }

            CurrentPosition = position;
            return null;
        }

        public void SetBoundary(Boundary boundary)
        {
            currentBoundary = boundary;
        }

        public override string ToString()
        {
            return $"{Id}: {CurrentPosition}";
        }
    }
}