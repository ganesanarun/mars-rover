using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Rover.Instruction
{
    public class InstructionProcessor
    {
        // ReSharper disable once CA1822
        public RoverPosition Process(RoverPosition currentPosition, IEnumerable<InstructionCommand> commands)
        {
            return commands.ToList().Aggregate(currentPosition, (position, command) => command.Execute(position));
        }
    }
}