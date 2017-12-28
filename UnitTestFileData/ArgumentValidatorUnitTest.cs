using System;
using System.Collections.Generic;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFileData
{
    [TestClass]
    /*
     * Unit test class for testing implementation of IArgumentValidator
     */
    public class ArgumentValidatorUnitTest
    {
        private IArgumentValidator _argumentValidator;
        private static readonly IEnumerable<string> ArgumentOptions = new List<string> { "-v" };
        private static readonly IEnumerable<string> ValidArgs = new List<string> { "-v", "c:/test.txt" };
        private static readonly IEnumerable<string> InValidArgs = new List<string> { "-d", "c:/test.txt" };
        private static readonly IEnumerable<string> InValidArgsWrongNumber = new List<string> { "-v", "c:/test.txt", "-d" };

        [TestMethod]
        [WorkItem(1)]
        public void ConstructorValidTest()
        {
            _argumentValidator = new ArgumentValidator(ValidArgs);
            Assert.IsNotNull(_argumentValidator);
        }

        [TestMethod]
        [WorkItem(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorContainsNullArgsTest()
        {
            _argumentValidator = new ArgumentValidator(null);
            Assert.IsNotNull(_argumentValidator);
        }


        [TestMethod]
        [WorkItem(1)]
        public void IsValidUsageShouldSucceedTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidArgs);
            var actual = _argumentValidator.IsValidUsage();
            Assert.AreEqual(expected,actual,"Expected success ");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsValidUsageShouldFailWhenInvalidArgumentsTest()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValidArgsWrongNumber);
            var actual = _argumentValidator.IsValidUsage();
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsValidUsageShouldFailWhenNumberOfValidArgumentsIsIncorrectTest()
        {
            const bool expected = false;
            const int numberofArguments = 99;
            _argumentValidator = new ArgumentValidator(InValidArgsWrongNumber, numberofArguments );
            var actual = _argumentValidator.IsValidUsage();
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersionTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidArgs);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldFailWhenArgsDoesNotContainVersionTest()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValidArgs);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsVersionRequiredShouldFailWhenArgumentOptionsIsNullTest()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValidArgs);
            var actual = _argumentValidator.IsVersionRequired(null);
            Assert.AreEqual(expected, actual, "Expected failure");
        }


    }
}
