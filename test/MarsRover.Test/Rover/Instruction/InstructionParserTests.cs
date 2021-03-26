using System.Linq;
using FluentAssertions;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover.Instruction
{
    public class InstructionParserTests
    {
        [Fact]
        public void ReturnSequenceOfCommands()
        {
            object[] expectedCommands =
            {
                new RightRotateCommand(), new LeftRotateCommand(), new MoveCommand()
            };

            var instructionCommands = InstructionParser.Parse("RLM");

            instructionCommands.ToList().Should().BeEquivalentTo(expectedCommands);
        }
    }
}