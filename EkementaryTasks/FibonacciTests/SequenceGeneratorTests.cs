using Xunit;
using Helpers;
using FibonacciSequence;
using System.Collections.Generic;
using System.Text;

namespace FibonacciSequence.Tests
{
    public class SequenceGeneratorTests
    {
        [Fact]
        public void Can_Generate_Sequence()
        {
            //Arrange 

            SequenceGenerator Generator = new SequenceGenerator();

            double from = 7D;

            double to = 144;

            //Act

            
            var result = Generator.GetSequence(from, to);

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Can_Generate_Ranged_Sequence()
        {
            //Arrange 

            SequenceGenerator Generator = new SequenceGenerator();

            double from = 7D;

            double to = 144;

            string expected = "8, 13, 21, 34, 55, 89, 144, ";

            //Act

            var sequence = Generator.GetSequence(from, to);

            StringBuilder result = new StringBuilder();

            foreach (var number in sequence)
            {
                result.Append(number);
                result.Append(", ");
            }
            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void Can_Get_Number_By_Row_Position()
        {
            //Arrange 

            SequenceGenerator Generator = new SequenceGenerator();

            double expected = 6765D;

            double positionNumber = 20;

            //Act

            var result = Generator.GetByPositionNumber(positionNumber);

            //Assert

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Can_Find_Nearest_Greater_Number()
        {
            //Arrange 

            SequenceGenerator Generator = new SequenceGenerator();

            double expected = 89D;

            double number = 56;

            double position;

            //Act

            var result = Generator.FindNearestNumber(number, out position);

            //Assert

            Assert.Equal(result, expected);
        }
    }
}
