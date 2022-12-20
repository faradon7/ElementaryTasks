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
        private Validator _validator;

        [SetUp]
        public void ValidatorTestsSetUp()
        {
            _validator = new Validator();
        }

        [Test]
        public void CheckEmptyString()
        {
            var result = _validator.IsValid("", validCheks.stringIsEmpty);
            Assert.IsTrue(result, "The result of this cool test was not true");
        }

        [Test]
        public void CheckIsValidNumber()
        {
            var result = _validator.IsValid("3453", validCheks.isNumber);
            Assert.IsTrue(result, "The result of this cool test was not true");
        }
    }
}
