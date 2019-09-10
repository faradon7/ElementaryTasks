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

            int from = 7;
            int to = 144;

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

            int from = 7;
            int to = 144;

            IEnumerable<int> expected = new int[] { 8, 13, 21, 34, 55, 89, 144 };

            //Act

            var result = Generator.GetSequence(from, to);

            //Assert

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Can_Return_Empty_Collection()
        {
            //Arrange 

            SequenceGenerator Generator = new SequenceGenerator();

            int from = 6;
            int to = 7;

            //var expected = 0;

            //Act

            var result = Generator.GetSequence(from, to);

            //Assert

            Assert.Empty(result);
        }
    }
}
