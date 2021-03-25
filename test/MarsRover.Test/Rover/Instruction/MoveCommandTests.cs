using System.Collections.Generic;
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
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);
            var roverPosition = new RoverPosition(1, 1, Cardinality.S);
            var expectedPosition = new RoverPosition(roverPosition.X, roverPosition.Y - 1, roverPosition.Cardinality);

            var (position, error) = moveCommand.Execute(roverPosition);

            error.Should().BeNull();
            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionUpWhenRoverCardinalityIsNorth()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);
            var roverPosition = new RoverPosition(1, 0, Cardinality.N);
            var expectedPosition = new RoverPosition(roverPosition.X, roverPosition.Y + 1, roverPosition.Cardinality);

            var (position, error) = moveCommand.Execute(roverPosition);

            error.Should().BeNull();
            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionLeftWhenRoverCardinalityIsWest()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);
            var roverPosition = new RoverPosition(1, 1, Cardinality.W);
            var expectedPosition = new RoverPosition(roverPosition.X - 1, roverPosition.Y, roverPosition.Cardinality);

            var (position, error) = moveCommand.Execute(roverPosition);

            error.Should().BeNull();
            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void MoveOnePositionRightWhenRoverCardinalityIsEast()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);
            var roverPosition = new RoverPosition(1, 1, Cardinality.E);
            var expectedPosition = new RoverPosition(roverPosition.X + 1, roverPosition.Y, roverPosition.Cardinality);

            var (position, error) = moveCommand.Execute(roverPosition);

            error.Should().BeNull();
            position.Should().Be(expectedPosition);
        }

        [Theory]
        [MemberData(nameof(OnBoundaryData))]
        public void ReturnErrorWhenTryToMoveBeyondBoundary(RoverPosition roverPosition)
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var moveCommand = new MoveCommand(boundary);

            var (position, error) = moveCommand.Execute(roverPosition);

            error.Should().NotBeNull().And.BeAssignableTo<InvalidCommandError>();
            position.Should().BeNull();
        }

        public static IEnumerable<object[]> OnBoundaryData =>
            new List<object[]>
            {
                new object[]
                {
                    new RoverPosition(0, 1, Cardinality.W)
                },
                new object[]
                {
                    new RoverPosition(5, 1, Cardinality.E)
                },
                new object[]
                {
                    new RoverPosition(1, 5, Cardinality.N)
                },
                new object[]
                {
                    new RoverPosition(1, 0, Cardinality.S)
                }
            };
    }
}