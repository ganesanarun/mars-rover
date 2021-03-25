using FluentAssertions;
using MarsRover.Rover;
using MarsRover.Rover.Instruction;
using Xunit;

namespace MarsRover.Test.Rover
{
    public class PlateauTests
    {
        [Fact]
        public void ReturnRoverWhenRoverExists()
        {
            var plateau = new Plateau(Boundary.WithMaximumXAndY(5, 5));
            const string roverId = "Rover1";
            var thisRover = new MarsRover.Rover.Rover(roverId, new RoverPosition(), new InstructionController());
            plateau.Land(thisRover);

            var actualRover = plateau.GetRoverWithThis(roverId);

            actualRover.Should().Be(thisRover);
        }
        
        [Fact]
        public void ReturnNullWhenRoverExists()
        {
            var plateau = new Plateau(Boundary.WithMaximumXAndY(5, 5));

            var actualRover = plateau.GetRoverWithThis("Rover1");

            actualRover.Should().BeNull();
        }
    }
}