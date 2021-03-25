using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class InstructionControllerTests
    {
        [Fact]
        public void MoveRoverAccordingToTheInstruction()
        {
            var rover = new MarsRover.Rover.Rover("Rover1", new RoverPosition(1, 2, Cardinality.N));
            var boundary = new Boundary(0, 5, 0, 5);
            var leftRotateCommand = new LeftRotateCommand();
            var moveCommand = new MoveCommand(boundary);

            var invalidCommandError = InstructionController.Control(rover, new InstructionCommand[]
            {
                leftRotateCommand,
                moveCommand,
                leftRotateCommand,
                moveCommand,
                leftRotateCommand,
                moveCommand,
                leftRotateCommand,
                moveCommand,
                moveCommand
            });

            invalidCommandError.Should().BeNull();
            rover.CurrentPosition.Should().BeEquivalentTo(new RoverPosition(1, 3, Cardinality.N));
        }

        [Fact]
        public void ReturnErrorWhenRandomCommandsWhereGiven()
        {
            var rover = new MarsRover.Rover.Rover("Rover2", new RoverPosition(5, 5, Cardinality.N));
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);

            var invalidCommandError = InstructionController.Control(rover, new InstructionCommand[]
            {
                moveCommand,
            });

            invalidCommandError.Should().NotBeNull();
        }
    }
}