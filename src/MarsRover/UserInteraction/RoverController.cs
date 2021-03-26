using MarsRover.Rover;
using MarsRover.Rover.Instruction;

namespace MarsRover.UserInteraction
{
    public class RoverController
    {
        public Plateau? Plateau { get; set; }

        public InvalidCommandError? Next(string input)
        {
            var instruction = InputParser.Parse(input);

            return instruction switch
            {
                PlateauInstruction plateauInstruction => Handle(plateauInstruction),
                RoverLandingInstruction landingInstruction => Handle(landingInstruction),
                RoverMoveInstruction roverMoveInstruction => Handle(roverMoveInstruction),
                _ => new InvalidCommandError("Unsupported instruction")
            };
        }

        private InvalidCommandError? Handle(RoverMoveInstruction roverMoveInstruction)
        {
            if (Plateau == null)
            {
                return new InvalidCommandError("No plateau to land the rover");
            }

            var roverWithThis = Plateau.GetRoverWithThis(roverMoveInstruction.RoverId);
            if (roverWithThis == null)
            {
                return new InvalidCommandError($"Unknown rover {roverMoveInstruction.RoverId}");
            }

            var instructionCommands = InstructionParser.Parse(roverMoveInstruction.Instruction);
            roverWithThis.FollowThe(instructionCommands);
            return null;
        }

        private InvalidCommandError? Handle(RoverLandingInstruction landingInstruction)
        {
            if (Plateau == null)
            {
                return new InvalidCommandError("No plateau to land the rover");
            }

            Plateau.Land(new Rover.Rover(landingInstruction.RoverId,
                new RoverPosition(landingInstruction.X, landingInstruction.Y, landingInstruction.Cardinality),
                new InstructionProcessor()));
            return null;
        }

        private InvalidCommandError? Handle(PlateauInstruction plateauInstruction)
        {
            Plateau = new Plateau(Boundary.WithMaximumXAndY(plateauInstruction.MaximumX,
                plateauInstruction.MaximumY));
            return null;
        }
    }
}