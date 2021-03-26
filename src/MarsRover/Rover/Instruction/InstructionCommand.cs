namespace MarsRover.Rover.Instruction
{
    public interface InstructionCommand
    {
        RoverPosition Execute(RoverPosition position);
    }
}