using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class InstructionProcessorTests
    {
        [Fact]
        public void ReturnTheNewPositionAccordingToTheCurrentPositionIfTheCommands()
        {
            var leftRotateCommand = new LeftRotateCommand();
            var moveCommand = new MoveCommand();
            var currentPosition = new RoverPosition(1, 2, Cardinality.N);
            var instructionController = new InstructionProcessor();
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

            var roverPosition = instructionController.Process(currentPosition, instructions);

            roverPosition.Should().BeEquivalentTo(new RoverPosition(1, 3, Cardinality.N));
        }
    }
}