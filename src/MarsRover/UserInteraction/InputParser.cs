using System;
using MarsRover.Rover;
using static System.Int32;

namespace MarsRover.UserInteraction
{
    public static class InputParser
    {
        private const string Landing = "Landing:";
        private const string Instructions = "Instructions:";
        private const string Plateau = "Plateau";

        public static Instruction Parse(string input)
        {
            input = input.Trim();
            if (IsPlateau(input))
            {
                return TryGetPlateauInstruction(input);
            }

            if (IsLandingInstruction(input))
            {
                return TryGetLandingInstruction(input, input.TextBefore(Landing).Trim());
            }

            if (IsRoverMovingInstruction(input))
            {
                return new RoverMoveInstruction(input.TextBefore(Instructions).Trim(),
                    input.TextAfter(Instructions).Trim());
            }

            return new NoOpInstruction();
        }

        private static bool IsRoverMovingInstruction(string invariantInput)
        {
            return invariantInput.Contains(Instructions);
        }

        private static bool IsLandingInstruction(string invariantInput)
        {
            return invariantInput.Contains(Landing);
        }

        private static Instruction TryGetLandingInstruction(string invariantInput, string roverId)
        {
            var coOrdinates = invariantInput.TextAfter(Landing).Trim();
            var split = coOrdinates.Split(" ");

            if (split.Length != 3)
            {
                return new NoOpInstruction();
            }

            var isValidX = TryParse(split[0], out var x);
            var isValidY = TryParse(split[1], out var y);
            var isValidCardinality = Enum.TryParse<Cardinality>(split[2].ToUpperInvariant(), out var cardinality);

            return isValidX && isValidY && isValidCardinality
                ? new RoverLandingInstruction(roverId, x, y, cardinality)
                : new NoOpInstruction();
        }

        private static Instruction TryGetPlateauInstruction(string invariantInput)
        {
            var noOpInstruction = new NoOpInstruction();
            var split = invariantInput.Split(":");
            if (split.Length != 2)
            {
                return noOpInstruction;
            }

            var sizes = split[1].Split(" ");
            if (sizes.Length != 2)
            {
                return noOpInstruction;
            }

            var isValidX = TryParse(sizes[0], out var maximumX);
            var isValidY = TryParse(sizes[1], out var maximumY);


            return isValidX && isValidY ? new PlateauInstruction(maximumX, maximumY) : noOpInstruction;
        }

        private static bool IsPlateau(string invariantInput)
        {
            var isPlateau = invariantInput.StartsWith(Plateau);
            return isPlateau;
        }
    }
}