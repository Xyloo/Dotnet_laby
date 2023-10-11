using System.Text.RegularExpressions;

namespace Lab2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperString()
        {
            decimal data = 0.05m;

            var result = MyFormatter.FormatUsdPrice(data);
            
            Assert.StartsWith("$0", result);
            Assert.Contains(".", result);
            Assert.EndsWith("05", result);
        }

        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperStringNoRoundUp()
        {
            decimal data = 0.123m;

            var result = MyFormatter.FormatUsdPrice(data);

            Assert.StartsWith("$0", result);
            Assert.Contains(".", result);
            Assert.EndsWith("12", result);
        }

        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperStringRoundedUp()
        {
            decimal data = 0.125m;

            var result = MyFormatter.FormatUsdPrice(data);

            Assert.StartsWith("$0", result);
            Assert.Contains(".", result);
            Assert.EndsWith("13", result);
        }

        [Theory]
        [InlineData(0.05)]
        [InlineData(.10)]
        [InlineData(1.65)]
        [InlineData(100.32)]
        [InlineData(-50.31)]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperStringRegex(decimal data)
        {
            var result = MyFormatter.FormatUsdPrice(data);
            var regex = new Regex(@"^\-?\$\d{1,}\.\d{2}$");

            Assert.Matches(regex, result);
        }
    }
}