using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Rover.Instruction
{
    public static class InstructionParser
    {
        public static IEnumerable<InstructionCommand> Parse(string input, Boundary boundary)
        {
            return input.ToUpperInvariant().ToCharArray().Select(character => From(character, boundary)).ToList();
        }

        private static InstructionCommand From(char inputCharacter, Boundary boundary)
        {
            return inputCharacter switch
            {
                'M' => new MoveCommand(boundary),
                'R' => new RightRotateCommand(),
                'L' => new LeftRotateCommand(),
                _ => throw new ArgumentException("Invalid input command")
            };
        }
    }
}