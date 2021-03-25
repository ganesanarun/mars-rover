using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class InstructionControllerTests
    {
        [Fact]
        public void ReturnTheNewPositionAccordingToTheCurrentPositionIfTheCommands()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var leftRotateCommand = new LeftRotateCommand();
            var moveCommand = new MoveCommand(boundary);
            var currentPosition = new RoverPosition(1, 2, Cardinality.N);
            var instructionController = new InstructionController();
            var instructions = new InstructionCommand[]
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
            };

            var (roverPosition, invalidCommandError) = instructionController.Receive(
                currentPosition,
                instructions);

            invalidCommandError.Should().BeNull();
            roverPosition.Should().BeEquivalentTo(new RoverPosition(1, 3, Cardinality.N));
        }

        [Fact]
        public void ReturnErrorWhenRandomCommandsWhereGiven()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);
            var currentPosition = new RoverPosition(5, 5, Cardinality.N);
            var instructionCommands = new InstructionCommand[] {moveCommand};
            var instructionController = new InstructionController();

            var (position, invalidCommandError) = instructionController.Receive(
                currentPosition,
                instructionCommands);

            invalidCommandError.Should().NotBeNull();
            position.Should().BeNull();
        }
    }
}