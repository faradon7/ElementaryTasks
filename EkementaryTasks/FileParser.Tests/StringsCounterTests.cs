using Moq;
using Xunit;
using Interfaces;
using FileParser;
using System.Collections.Generic;

namespace FileParser.Tests
{
    public class StringsCounterTests
    {
        [Fact]
        public void Can_Count_Amount_Of_String_Entries()
        {
            //Arrange 
            var entry = "Hello";
            var expectedAmountOfEntries = 2;

            IEnumerable<string> FileContent = new List<string> { "Hello World!", "hello Ukraine" };


            StringsCounter counter = new StringsCounter(entry, FileContent);

            //Act

            counter.Count();
            var result = counter.Amount;

            //Assert

            Assert.Equal(expectedAmountOfEntries, result);
        }
    }
}
