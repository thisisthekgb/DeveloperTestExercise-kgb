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
        private static readonly IEnumerable<string> ArgumentOptions = new List<string> { "-v","--v","/v","-version","-s","--s","/s","-size" };

        private static readonly IEnumerable<string> ValidVersion1Args = new List<string> { "-v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion2Args = new List<string> { "--v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion3Args = new List<string> { "/v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion4Args = new List<string> { "-version", "c:/test.txt" };

        private static readonly IEnumerable<string> ValidSize1Args = new List<string> { "-s", "c:/test.txt" };

        private static readonly IEnumerable<string> InValidArgs = new List<string> { "-d", "c:/test.txt" };

        private static readonly IEnumerable<string> InValidArgsWrongNumber = new List<string> { "-v", "c:/test.txt", "-d" };

        [TestMethod]
        [WorkItem(1)]
        public void ConstructorValidTest()
        {
            _argumentValidator = new ArgumentValidator(ValidVersion1Args);
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
            _argumentValidator = new ArgumentValidator(ValidVersion1Args);
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
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion1ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion1Args);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion2ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion2Args);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion3ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion3Args);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion4ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion4Args);
            var actual = _argumentValidator.IsVersionRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected success");
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


        [TestMethod]
        [WorkItem(2)]
        public void IsSizeRequiredShouldSuccedWhenArgumentOptionsContainsSizeTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidSize1Args);
            var actual = _argumentValidator.IsSizeRequired(ArgumentOptions);
            Assert.AreEqual(expected, actual, "Expected success");
        }


    }
}
