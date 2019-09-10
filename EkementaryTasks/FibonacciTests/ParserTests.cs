using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Interfaces;
using Helpers;

namespace FibonacciSequence.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Can_Extract_Only_Digits()
        {
            //Arrange 

            INumberParser Parser = new Parser();

            var digitsWithChars = new[] { "b0po", "b45y7ikj8" };

            //Act

            bool isExtracted;

            var result = Parser.ExtractDigits(digitsWithChars, out isExtracted);

            //Assert
            Assert.True(isExtracted);
            Assert.Equal(1D, result[0]);
            Assert.Equal(4578D, result[1]);
        }

        [Fact]
        public void Can_Parse_String_To_Integer()
        {
            //Arrange 

            INumberParser Parser = new Parser();

            var digitsWithChars = new[] { "15", "56" };

            //Act

            bool isExtracted;

            var result = Parser.ExtractDigits(digitsWithChars, out isExtracted);

            //Assert
            Assert.True(isExtracted);
            Assert.Equal(15D, result[0]);
            Assert.Equal(56D, result[1]);
        }
    }
}
