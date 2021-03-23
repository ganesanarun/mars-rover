namespace MarsRover.Rover.Instruction
{
    public interface IInstructionCommand
    {
        (RoverPosition? position, InvalidCommandError? error) Execute(RoverPosition position);
    }
}