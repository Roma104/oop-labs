using Simulator;
using Xunit;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-1, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldClampValues(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("hello", 3, 10, '#', "Hello")]
    [InlineData("  hi  ", 3, 10, '#', "Hi#")]
    [InlineData("longstringvalue", 3, 5, '#', "Longs")]
    [InlineData("   ", 3, 5, '#', "###")]
    [InlineData("test", 3, 5, '#', "Test")]
    [InlineData("a", 3, 5, '#', "A##")]
    [InlineData("lowercase", 0, 10, '#', "Lowercase")]
    public void Shortener_ShouldReturnExpectedResult(string input, int min, int max, char placeholder, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(input, min, max, placeholder));
    }
}
