using FluentAssertions;
using Xunit;

namespace MarsRover.Test
{
    public class SampleTest
    {
        [Fact]
        public void PassAllTheTime()
        {
            true.Should().BeTrue();
        }
    }
}
