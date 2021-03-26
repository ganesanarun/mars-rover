using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Rover
{
    public class Plateau
    {
        private readonly Boundary boundary;

        private readonly Dictionary<string, Rover> rovers;

        public Plateau(Boundary boundary)
        {
            this.boundary = boundary;
            rovers = new Dictionary<string, Rover>();
        }

        public void Land(Rover thisRover)
        {
            rovers.Add(thisRover.Id, thisRover);
            thisRover.SetBoundary(boundary);
        }

        public Rover? GetRoverWithThis(string id)
        {
            rovers.TryGetValue(id, out var key);
            return key;
        }

        public IEnumerable<Rover> AllRovers()
        {
            return rovers.Values.Select(rover => rover);
        }
    }
}