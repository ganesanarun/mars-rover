using FluentAssertions;
using MarsRover.Rover;
using Xunit;

namespace MarsRover.Test.Rover
{
    public class BoundaryTests
    {
        [Fact]
        public void ReturnTrueWhenPositionIsWithinBoundary()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var inclusiveXPosition = new RoverPosition(0, 1, Cardinality.E);
            var exclusiveXPosition = new RoverPosition(0, 0, Cardinality.E);
            var inclusiveYPosition = new RoverPosition(1, 0, Cardinality.E);
            var exclusiveYPosition = new RoverPosition(0, 4, Cardinality.E);

            var inclusiveXResult = boundary.IsAllowedPosition(inclusiveXPosition);
            var inclusiveYResult = boundary.IsAllowedPosition(inclusiveYPosition);
            var exclusiveXResult = boundary.IsAllowedPosition(exclusiveXPosition);
            var exclusiveYResult = boundary.IsAllowedPosition(exclusiveYPosition);

            inclusiveXResult.Should().BeTrue();
            inclusiveYResult.Should().BeTrue();
            exclusiveXResult.Should().BeTrue();
            exclusiveYResult.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseWhenXCoOrdinateIsNotWithinBoundary()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var extremeXPosition = new RoverPosition(-1, 0, Cardinality.E);
            var extremeYPosition = new RoverPosition(-1, 0, Cardinality.E);
            var farBeyondXPosition = new RoverPosition(5, 0, Cardinality.E);
            var farBeyondYPosition = new RoverPosition(0, 5, Cardinality.E);

            var extremeLeftResult = boundary.IsAllowedPosition(extremeXPosition);
            var extremeYResult = boundary.IsAllowedPosition(extremeYPosition);
            var farBeyondXLimitResult = boundary.IsAllowedPosition(farBeyondXPosition);
            var farBeyondYLimitResult = boundary.IsAllowedPosition(farBeyondYPosition);

            extremeLeftResult.Should().BeFalse();
            extremeYResult.Should().BeFalse();
            farBeyondXLimitResult.Should().BeFalse();
            farBeyondYLimitResult.Should().BeFalse();
        }
    }
}