using System;
using System.IO;
using System.Collections.Generic;
using Moq;
using Xunit;
using Interfaces;

namespace FileParser.Tests
{
    public class StringReplacerTests
    {
        [Fact]
        public void Can_Replace_Substrings()
        {
            //Arrange

            var entryWord = "Hello";
            var replacement = "Hi";

            List<string> ResultFile = new List<string>();

            var writeStreamProvider = new Mock<IWriteStreamProvider>();

            var memoryStream = new MemoryStream();

            var streamWriter = new Mock<StreamWriter>(memoryStream);

            writeStreamProvider.Setup(s => s.GetWriter())
                .Returns(streamWriter.Object);

            streamWriter.Setup(sw => sw.WriteLine(It.IsAny<string>()))
                .Callback((string s) => ResultFile.Add(s));

            IEnumerable<string> sourceFileContent =
                new List<string> { "Hello World!", "HelloEveryone" };

            List<string> expectedResult =
                new List<string> { "Hi World!", "HiEveryone" };

            StringReplacer replacer = new StringReplacer(entryWord, 
                replacement, sourceFileContent, writeStreamProvider.Object);

            //Act

            replacer.Replace();
            memoryStream.Close();

            //Assert

            Assert.Equal(expectedResult, ResultFile);
        }

        [Fact]
        public void Can_Count_Replacements()
        {
            //Arrange

            var entryWord = "Hello";
            var replacement = "Hi";

            var writeStreamProvider = new Mock<IWriteStreamProvider>();
            var memoryStream = new MemoryStream();
            var streamWriter = new Mock<StreamWriter>(memoryStream);

            writeStreamProvider.Setup(s => s.GetWriter())
                .Returns(streamWriter.Object);

            IEnumerable<string> sourceFileContent =
                new List<string> { "Hello World!", "HelloEveryone" };

            var expectedAmount = 2;

            StringReplacer replacer = new StringReplacer(entryWord,
                replacement, sourceFileContent, writeStreamProvider.Object);

            //Act

            replacer.Replace();
            var result = replacer.Amount;
            memoryStream.Close();

            //Assert

            Assert.Equal(expectedAmount, replacer.Amount);
        }
    }
}
