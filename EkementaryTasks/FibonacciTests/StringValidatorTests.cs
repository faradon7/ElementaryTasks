using Moq;
using Xunit;
using Interfaces;
using Helpers;

namespace FibonacciSequence.Tests
{
    public class StringValidatorTests
    {
        [Fact]
        public void Can_Validate_Empty_String()
        {
            //Arrange 

            IStringValidator StringValidator = new Validator();

            var empty = string.Empty;

            //Act

            var result = StringValidator.IsValid(empty);

            //Assert

            Assert.False(result);
        }

        [Fact]
        public void Can_Validate_Null()
        {
            //Arrange 

            IStringValidator StringValidator = new Validator();

            string nullable = null;

            //Act

            var result = StringValidator.IsValid(nullable);

            //Assert

            Assert.False(result);
        }

        [Fact]
        public void Can_Validate_White_Spaces()
        {
            //Arrange 

            IStringValidator StringValidator = new Validator();

            var argWithWhiteSpace = " ";

            //Act

            var result = StringValidator.IsValid(argWithWhiteSpace);

            //Assert

            Assert.False(result);
        }

        [Fact]
        public void Can_Validate_Range()
        {
            //Arrange 

            INumberValidator NumberValidator = new Validator();

            var incorrectRange = new double[] { 57, 56 };

            //Act

            var result = NumberValidator.IsValidNumbers(incorrectRange);

            //Assert

            Assert.False(result);
        }
    }
}
