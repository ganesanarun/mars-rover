using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover
{
    public class RoverTests
    {
        [Fact]
        public void MoveRoverWhenCommandsAreProper()
        {
            var boundary = Boundary.WithMaximumXAndY(5, 5);
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
            var rover = new MarsRover.Rover.Rover("Rover1", currentPosition, instructionController);
            rover.SetBoundary(boundary);

            var invalidCommandError = rover.FollowThe(instructions);

            invalidCommandError.Should().BeNull();
            rover.CurrentPosition.Should().BeEquivalentTo(new RoverPosition(1, 3, Cardinality.N));
        }

        [Fact]
        public void ReturnAnErrorWhenInstructionsAreMakingItMoveBeyondTheBoundaryAndCurrentPositionShouldNotChange()
        {
            var boundary = Boundary.WithMaximumXAndY(5, 5);
            var moveCommand = new MoveCommand();
            var currentPosition = new RoverPosition(5, 5, Cardinality.E);
            var instructionController = new InstructionProcessor();
            var instructions = new InstructionCommand[]
            {
                moveCommand
            };
            var rover = new MarsRover.Rover.Rover("Rover1", currentPosition, instructionController);
            rover.SetBoundary(boundary);

            var invalidCommandError = rover.FollowThe(instructions);

            invalidCommandError.Should().NotBeNull();
            rover.CurrentPosition.Should().BeEquivalentTo(currentPosition);
        }
        
        [Fact]
        public void MoveOneLevelLeftWhenThereIsNoBoundary()
        {
            var moveCommand = new MoveCommand();
            var currentPosition = new RoverPosition(5, 5, Cardinality.E);
            var instructionController = new InstructionProcessor();
            var instructions = new InstructionCommand[]
            {
                moveCommand
            };
            var rover = new MarsRover.Rover.Rover("Rover1", currentPosition, instructionController);

            var invalidCommandError = rover.FollowThe(instructions);

            invalidCommandError.Should().BeNull();
            rover.CurrentPosition.Should().BeEquivalentTo(new RoverPosition(6, 5, Cardinality.E));
        }
    }
}