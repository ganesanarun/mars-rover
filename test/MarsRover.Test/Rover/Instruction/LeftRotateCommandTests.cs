using System.Collections.Generic;
using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class LeftRotateCommandTests
    {
        [Theory]
        [MemberData(nameof(InputWithExpectedOutput))]
        public void RotateAntiClockWise(RoverPosition currentPosition, RoverPosition expectedPosition)
        {
            var leftRotateCommand = new LeftRotateCommand();

            var position = leftRotateCommand.Execute(currentPosition);

            position.Should().BeEquivalentTo(expectedPosition);
        }

        public static IEnumerable<object[]> InputWithExpectedOutput =>
            new List<object[]>
            {
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.E), new RoverPosition(0, 0, Cardinality.N)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.N), new RoverPosition(0, 0, Cardinality.W)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.W), new RoverPosition(0, 0, Cardinality.S)
                },
                new object[]
                {
                    new RoverPosition(0, 0, Cardinality.S), new RoverPosition(0, 0, Cardinality.E)
                }
            };
    }
}