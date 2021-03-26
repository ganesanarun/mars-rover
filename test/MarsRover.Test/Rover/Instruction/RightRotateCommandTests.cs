using System.Collections.Generic;
using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class RightRotateCommandTests
    {
        public static IEnumerable<object[]> InputWithExpectedOutput =>
            new List<object[]>
            {
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.E), new RoverPosition(0, 0, Cardinality.S)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.N), new RoverPosition(0, 0, Cardinality.E)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.W), new RoverPosition(0, 0, Cardinality.N)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.S), new RoverPosition(0, 0, Cardinality.W)
                }
            };

        [Theory]
        [MemberData(nameof(InputWithExpectedOutput))]
        public void RotateClockWise(RoverPosition currentPosition, RoverPosition expectedPosition)
        {
            var leftRotateCommand = new RightRotateCommand();

            var position = leftRotateCommand.Execute(currentPosition);

            position.Should().BeEquivalentTo(expectedPosition);
        }
    }
}