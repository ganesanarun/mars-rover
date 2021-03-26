using FluentAssertions;
using MarsRover.Rover;
using MarsRover.UserInteraction;
using Xunit;

namespace MarsRover.Test.UserInteraction
{
    public class InputParserTests
    {
        [Fact]
        public void ReturnPlateauInstruction()
        {
            var instruction = InputParser.Parse("Plateau:5 5");

            instruction.Should().Be(new PlateauInstruction(5, 5));
        }

        [Fact]
        public void ReturnRoverLandingInstruction()
        {
            var instruction = InputParser.Parse("Rover1 Landing:1 2 N");

            instruction.Should().Be(new RoverLandingInstruction("Rover1", 1, 2, Cardinality.N));
        }
        
        [Fact]
        public void ReturnRoverMovingInstruction()
        {
            var instruction = InputParser.Parse("Rover1 Instructions:LMLMLMLMM");

            instruction.Should().Be(new RoverMoveInstruction("Rover1", "LMLMLMLMM"));
        }
    }
}