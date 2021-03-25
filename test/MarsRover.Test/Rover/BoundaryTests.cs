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
            var inclusiveMinXPosition = new RoverPosition(0, 1, Cardinality.E);
            var inclusiveMaxXPosition = new RoverPosition(5, 0, Cardinality.E);
            var inclusiveMinYPosition = new RoverPosition(1, 0, Cardinality.E);
            var inclusiveMaxYPosition = new RoverPosition(0, 5, Cardinality.E);

            var inclusiveXResult = boundary.IsAllowedPosition(inclusiveMinXPosition);
            var inclusiveYResult = boundary.IsAllowedPosition(inclusiveMinYPosition);
            var inclusiveMaxXResult = boundary.IsAllowedPosition(inclusiveMaxXPosition);
            var inclusiveMaxYResult = boundary.IsAllowedPosition(inclusiveMaxYPosition);

            inclusiveXResult.Should().BeTrue();
            inclusiveYResult.Should().BeTrue();
            inclusiveMaxXResult.Should().BeTrue();
            inclusiveMaxYResult.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseWhenXAndYCoordinateIsNotWithinBoundary()
        {
            var boundary = new Boundary(0, 5, 0, 5);
            var extremeXPosition = new RoverPosition(-1, 0, Cardinality.E);
            var extremeYPosition = new RoverPosition(0, -1, Cardinality.E);
            var farBeyondXPosition = new RoverPosition(6, 0, Cardinality.E);
            var farBeyondYPosition = new RoverPosition(0, 6, Cardinality.E);

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