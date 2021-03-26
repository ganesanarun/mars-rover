using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Rover.Instruction
{
    public static class InstructionParser
    {
        public static IEnumerable<InstructionCommand> Parse(string input)
        {
            return input.ToUpperInvariant().ToCharArray().Select(From).ToList();
        }

        private static InstructionCommand From(char inputCharacter)
        {
            return inputCharacter switch
            {
                'M' => new MoveCommand(),
                'R' => new RightRotateCommand(),
                'L' => new LeftRotateCommand(),
                _ => throw new ArgumentException("Invalid input command")
            };
        }
    }
}