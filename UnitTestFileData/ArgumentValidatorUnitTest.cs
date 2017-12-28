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

        private static readonly IEnumerable<string> ValidVersion1Args = new List<string> { "-v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion2Args = new List<string> { "--v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion3Args = new List<string> { "/v", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidVersion4Args = new List<string> { "-version", "c:/test.txt" };

        private static readonly IEnumerable<string> ValidSize1Args = new List<string> { "-s", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidSize2Args = new List<string> { "--s", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidSize3Args = new List<string> { "/s", "c:/test.txt" };
        private static readonly IEnumerable<string> ValidSize4Args = new List<string> { "-size", "c:/test.txt" };

        private static readonly IEnumerable<string> InValid1Args = new List<string> { "-d", "c:/test.txt" };
        private static readonly IEnumerable<string> InValid2Args = new List<string> { "-sizeisnotright", "c:/test.txt" };
        private static readonly IEnumerable<string> InValid3Args = new List<string> { "-versionisnotright", "c:/test.txt" };

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
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(2)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion2ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion2Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(2)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion3ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion3Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(2)]
        public void IsVersionRequiredShouldSucceedWhenArgumentOptionContainsVersion4ArgsTest()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidVersion4Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldFailWhenArgsDoNotContainValidVersionOption1Test()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValid1Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldFailWhenArgsDoNotContainValidVersionOption2Test()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValid2Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(1)]
        public void IsVersionRequiredShouldFailWhenArgsDoNotContainValidVersionOption3Test()
        {
            const bool expected = false;
            _argumentValidator = new ArgumentValidator(InValid3Args);
            var actual = _argumentValidator.IsVersionRequired();
            Assert.AreEqual(expected, actual, "Expected failure");
        }

        [TestMethod]
        [WorkItem(2)]
        public void IsSizeRequiredShouldSucceedWhenArgumentOptionsContainsSize1Test()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidSize1Args);
            var actual = _argumentValidator.IsSizeRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

        [TestMethod]
        [WorkItem(2)]
        public void IsSizeRequiredShouldSucceedWhenArgumentOptionsContainsSize2Test()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidSize2Args);
            var actual = _argumentValidator.IsSizeRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }
        [TestMethod]
        [WorkItem(2)]
        public void IsSizeRequiredShouldSucceedWhenArgumentOptionsContainsSize3Test()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidSize3Args);
            var actual = _argumentValidator.IsSizeRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }
        [TestMethod]
        [WorkItem(2)]
        public void IsSizeRequiredShouldSucceedWhenArgumentOptionsContainsSize4Test()
        {
            const bool expected = true;
            _argumentValidator = new ArgumentValidator(ValidSize4Args);
            var actual = _argumentValidator.IsSizeRequired();
            Assert.AreEqual(expected, actual, "Expected success");
        }

    }
}
