using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class MoveCommandTests
    {
        [Fact]
        public void MoveOnePositionDownWhenRoverCardinalityIsSouth()
        {
            var moveCommand = new MoveCommand();
            var roverPosition = new RoverPosition(1, 1, Cardinality.S);
            var expectedPosition = new RoverPosition(roverPosition.X, roverPosition.Y - 1, roverPosition.Cardinality);

            var position = moveCommand.Execute(roverPosition);

            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionUpWhenRoverCardinalityIsNorth()
        {
            var moveCommand = new MoveCommand();
            var roverPosition = new RoverPosition(1, 0, Cardinality.N);
            var expectedPosition = new RoverPosition(roverPosition.X, roverPosition.Y + 1, roverPosition.Cardinality);

            var position = moveCommand.Execute(roverPosition);

            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionLeftWhenRoverCardinalityIsWest()
        {
            var moveCommand = new MoveCommand();
            var roverPosition = new RoverPosition(1, 1, Cardinality.W);
            var expectedPosition = new RoverPosition(roverPosition.X - 1, roverPosition.Y, roverPosition.Cardinality);

            var position = moveCommand.Execute(roverPosition);

            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionRightWhenRoverCardinalityIsEast()
        {
            var moveCommand = new MoveCommand();
            var roverPosition = new RoverPosition(1, 1, Cardinality.E);
            var expectedPosition = new RoverPosition(roverPosition.X + 1, roverPosition.Y, roverPosition.Cardinality);

            var position = moveCommand.Execute(roverPosition);

            position.Should().Be(expectedPosition);
        }
    }
}