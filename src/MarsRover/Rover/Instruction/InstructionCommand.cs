namespace MarsRover.Rover.Instruction
{
    public interface InstructionCommand
    {
        (RoverPosition? position, InvalidCommandError? error) Execute(RoverPosition position);
    }
}