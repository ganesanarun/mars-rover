using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Rover.Instruction
{
    public class InstructionController
    {
        // ReSharper disable once CA1822
        public (RoverPosition?, InvalidCommandError?) Receive(RoverPosition currentPosition,
            IEnumerable<InstructionCommand> commands)
        {
            RoverPosition? position = currentPosition;
            InvalidCommandError? e = null;

            return commands.ToList().Aggregate((position, e),
                (o, command) => o.e == null ? command.Execute(o.position!.Value) : o);
        }
    }
}