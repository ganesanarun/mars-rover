using System.Linq;
using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class InstructionParserTests
    {
        [Fact]
        public void ReturnSequenceOfCommands()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            object[] expectedCommands =
            {
                new RightRotateCommand(), new LeftRotateCommand(), new MoveCommand(boundary)
            };

            var instructionCommands = InstructionParser.Parse("RLM", boundary);

            instructionCommands.ToList().Should().BeEquivalentTo(expectedCommands);
        }
    }
}