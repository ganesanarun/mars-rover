using System.ComponentModel;

namespace MarsRover.Rover
{
    public enum Cardinality
    {
        [Description("North")] N,
        [Description("South")] S,
        [Description("East")] E,
        [Description("West")] W
    }
}