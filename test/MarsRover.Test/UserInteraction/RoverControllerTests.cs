using FluentAssertions;
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
            var output = roverController.Handle(new NoOpInstruction());

            output.Should().NotBeNull();
            output.Should().Be("Rover1: 1 3 N\nRover2: 5 1 E");
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