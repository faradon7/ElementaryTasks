using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalClasses;
using NUnit.Framework;
using Interfaces;

namespace FibonacciSequence.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        public Validator validator;

        [SetUp]
        public void ValidatorTestsSetUp()
        {
            validator = new Validator();
        }

        [Test]
        public void CheckEmptyString()
        {
            var result = validator.IsValid("", validCheks.stringIsEmpty);
            Assert.IsTrue(result, "The result of this cool test was not true");
        }

        [Test]
        public void CheckIsValidNumber()
        {
            var result = validator.IsValid("3453", validCheks.isNumber);
            Assert.IsTrue(result, "The result of this cool test was not true");
        }
    }
}
