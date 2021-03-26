using FluentAssertions;
using MarsRover.Rover;
using MarsRover.UserInteraction;
using Xunit;

namespace MarsRover.Test.UserInteraction
{
    public class RoverControllerTests
    {
        [Fact]
        public void MoveRovesToProperPosition()
        {
            var roverController = new RoverController();
            const string rover2Id = "Rover2";
            const string rover1Id = "Rover1";

            roverController.Next("Plateau:5 5");
            roverController.Next($"{rover1Id} Landing:1 2 N");
            roverController.Next($"{rover1Id}  Instructions:LMLMLMLMM");
            roverController.Next($"{rover2Id} Landing:3 3 E");
            roverController.Next($"{rover2Id} Instructions:MMRMMRMRRM");

            roverController.Plateau.Should().NotBeNull();
            var rover1 = roverController.Plateau!.GetRoverWithThis(rover1Id);
            rover1.Should().NotBeNull();
            rover1!.Id.Should().Be(rover1Id);
            rover1.CurrentPosition.Should().Be(new RoverPosition(1, 3, Cardinality.N));
            var rover2 = roverController.Plateau!.GetRoverWithThis(rover2Id);
            rover2.Should().NotBeNull();
            rover2!.Id.Should().Be(rover2Id);
            rover2.CurrentPosition.Should().Be(new RoverPosition(5, 1, Cardinality.E));
        }

        [Fact]
        public void ReturnInvalidInstructionErrorWhenPlateauIsNotThereForRoverToLand()
        {
            var roverController = new RoverController();

            var invalidInstructionError = roverController.Next("Rover1 Landing:1 2 N");

            invalidInstructionError.Should().NotBeNull();
        }

        [Fact]
        public void ReturnInvalidCommandErrorWhenUnknownInstructionIsGiven()
        {
            var roverController = new RoverController();

            var invalidCommandError = roverController.Next("Random instruction");

            invalidCommandError.Should().NotBeNull();
        }
    }
}