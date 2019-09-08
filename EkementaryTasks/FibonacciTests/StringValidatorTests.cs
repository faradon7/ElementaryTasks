using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciTests
{
    class StringValidatorTests
    {
        [Fact]
        public void Can_Validate_Only_Digits()
        {
            //Arrange 

            INumberParser Parser = new Parser();

            var digitsWithChars = new[] { "b45y7ikj8", "b0po" };

            //Act

            bool isExtracted;

            var result = Parser.ExtractDigits(digitsWithChars, out isExtracted);

            //Assert
            Assert.True(isExtracted);
            Assert.Equal(4578D, result[0]);
            Assert.Equal(1D, result[1]);
        }
    }
}
