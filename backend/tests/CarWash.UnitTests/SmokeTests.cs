using FluentAssertions;
using Xunit;

namespace CarWash.UnitTests;

public class SmokeTests
{
    [Fact]
    public void Sanity_check_passes()
    {
        (1 + 1).Should().Be(2);
    }
}
