using System.Collections.Generic;

namespace MarsRover.Rover.Instruction
{
    public static class InstructionController
    {
        public static InvalidCommandError? Control(Rover thisRover, IEnumerable<InstructionCommand> commands)
        {
            foreach (var instructionCommand in commands)
            {
                var (position, error) = instructionCommand.Execute(thisRover.CurrentPosition);

                if (error != null)
                {
                    return error;
                }

                thisRover.MoveTo(position!.Value);
            }

            return null;
        }
    }
}