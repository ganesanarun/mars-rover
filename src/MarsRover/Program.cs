using System;
using System.Threading.Tasks;
using MarsRover.UserInteraction;

namespace MarsRover
{
    internal static class Program
    {
        private static async Task Main()
        {
            string? input;
            var roverController = new RoverController();
            while ((input = await Console.In.ReadLineAsync()) != null)
            {
                if (string.IsNullOrEmpty(input.Trim()))
                {
                    break;
                }

                var invalidCommandError = roverController.Next(input);
                if (invalidCommandError == null)
                {
                    continue;
                }

                Console.WriteLine(invalidCommandError.Message);
                break;
            }

            var result = roverController.Handle(new NoOpInstruction());

            Console.WriteLine(result);
        }
    }
}