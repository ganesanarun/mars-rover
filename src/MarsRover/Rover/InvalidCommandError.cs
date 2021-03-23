using System;
using System.Runtime.Serialization;

namespace MarsRover.Rover
{
    public class InvalidCommandError : Exception
    {
        public InvalidCommandError()
        {
        }

        protected InvalidCommandError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCommandError(string? message) : base(message)
        {
        }

        public InvalidCommandError(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}