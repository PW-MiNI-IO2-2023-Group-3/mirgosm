using io2_workshop;

namespace io2_workshop_tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.SumString("");
            Assert.Equal(0,result);
        }

        [Theory]
        [InlineData("12",12)]
        [InlineData("13",13)]
        [InlineData("0",0)]
        public void SingleNumberReturnsValue(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }

        [Theory]
        [InlineData("12,13",25)]
        [InlineData("12,4",16)]
        [InlineData("0,3",3)]
        public void CommaSeparatedReturnSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }

        [Theory]
        [InlineData("12\n13",25)]
        [InlineData("12\n4",16)]
        [InlineData("-1\n3",3)]
        public void NewlineSeparatedReturnSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }

        [Theory]
        [InlineData("1,12\n13",26)]
        [InlineData("1\n4,2",7)]
        public void NewlineOrSplSeparatedReturnSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-1,2\n3")]
        [InlineData("-1,-2\n3")]
        public void NegtiveReturnArgException(string str)
        {
            Assert.Throws<ArgumentException>(() => { StringCalculator.SumString(str); });
        }

        [Theory]
        [InlineData("1001,12\n13",25)]
        [InlineData("1\n4,2000",5)]
        [InlineData("2000",0)]
        public void GreaterThanThousandReturnSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }

        [Theory]
        [InlineData("//a\n1a12a13",26)]
        [InlineData("//$\n1\n4$2000",5)]
        [InlineData("//p\n2000",0)]
        public void CustomSeparator(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue,result);
        }
    }
}