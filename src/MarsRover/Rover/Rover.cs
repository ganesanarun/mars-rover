using System.Collections.Generic;
using MarsRover.Rover.Instruction;

namespace MarsRover.Rover
{
    public class Rover
    {
        private readonly InstructionController controller;

        public Rover(string id, RoverPosition currentPosition, InstructionController controller)
        {
            this.controller = controller;
            Id = id;
            CurrentPosition = currentPosition;
        }

        public string Id { get; private set; }

        public RoverPosition CurrentPosition { get; private set; }

        public InvalidCommandError? Receive(IEnumerable<InstructionCommand> instructions)
        {
            var (position, error) = controller.Receive(CurrentPosition, instructions);
            if (error != null)
            {
                return error;
            }

            CurrentPosition = position!.Value;
            return null;
        }
    }
}