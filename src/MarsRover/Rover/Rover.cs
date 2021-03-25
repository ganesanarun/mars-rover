namespace MarsRover.Rover
{
    public class Rover
    {
        public Rover(string id, RoverPosition currentPosition)
        {
            Id = id;
            CurrentPosition = currentPosition;
        }

        public string Id { get; private set; }

        public RoverPosition CurrentPosition { get; private set; }

        public void MoveTo(RoverPosition thisPosition)
        {
            CurrentPosition = thisPosition;
        }
    }
}