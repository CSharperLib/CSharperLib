using CSharperLib.Extensions;
using Xunit;

namespace CSharperLib.Tests.Extensions
{
    public class StringExtensions
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", false)]
        [InlineData("\t", false)]
        [InlineData("\r", false)]
        [InlineData("\n", false)]
        [InlineData("\r\n", false)]
        [InlineData("ABC", false)]
        public void IsNullOrEmpty(string value, bool expected)
        {
            // Act
            bool result = value.IsNullOrEmpty();

            // Assert
            Assert.Equal(expected, result);
        }


        // --- IsNullOrWhiteSpace ---

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("\t", true)]
        [InlineData("\r", true)]
        [InlineData("\n", true)]
        [InlineData("\r\n", true)]
        [InlineData("ABC", false)]
        public void IsNullOrWhiteSpace(string value, bool expected)
        {
            // Act
            bool result = value.IsNullOrWhiteSpace();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
