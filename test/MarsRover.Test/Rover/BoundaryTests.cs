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
            var boundary = Boundary.WithMaximumXAndY(5, 5);
            var inclusiveMinXPosition = new RoverPosition(0, 1, Cardinality.E);
            var inclusiveMaxXPosition = new RoverPosition(5, 0, Cardinality.E);
            var inclusiveMinYPosition = new RoverPosition(1, 0, Cardinality.E);
            var inclusiveMaxYPosition = new RoverPosition(0, 5, Cardinality.E);

            var inclusiveXResult = boundary.CanIMoveToThis(inclusiveMinXPosition);
            var inclusiveYResult = boundary.CanIMoveToThis(inclusiveMinYPosition);
            var inclusiveMaxXResult = boundary.CanIMoveToThis(inclusiveMaxXPosition);
            var inclusiveMaxYResult = boundary.CanIMoveToThis(inclusiveMaxYPosition);

            inclusiveXResult.Should().BeTrue();
            inclusiveYResult.Should().BeTrue();
            inclusiveMaxXResult.Should().BeTrue();
            inclusiveMaxYResult.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseWhenXAndYCoordinateIsNotWithinBoundary()
        {
            var boundary = Boundary.WithMaximumXAndY(5, 5);
            var extremeXPosition = new RoverPosition(-1, 0, Cardinality.E);
            var extremeYPosition = new RoverPosition(0, -1, Cardinality.E);
            var farBeyondXPosition = new RoverPosition(6, 0, Cardinality.E);
            var farBeyondYPosition = new RoverPosition(0, 6, Cardinality.E);

            var extremeLeftResult = boundary.CanIMoveToThis(extremeXPosition);
            var extremeYResult = boundary.CanIMoveToThis(extremeYPosition);
            var farBeyondXLimitResult = boundary.CanIMoveToThis(farBeyondXPosition);
            var farBeyondYLimitResult = boundary.CanIMoveToThis(farBeyondYPosition);

            extremeLeftResult.Should().BeFalse();
            extremeYResult.Should().BeFalse();
            farBeyondXLimitResult.Should().BeFalse();
            farBeyondYLimitResult.Should().BeFalse();
        }
    }
}