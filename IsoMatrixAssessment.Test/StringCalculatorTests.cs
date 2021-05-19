
using System;
using NUnit.Framework;
using IsoMatrix.AssessmentTest;

namespace IsoMatrixAssessment.Test
{
    [TestFixture]
    public class StringCalculatorTests
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddWithNullStringThrowsException()
        {
            StringCalculator.Add(null);
        }

        [Test]
        public void TestAddWithEmptyStringReturnsZero()
        {
            string numbers = string.Empty;
            int result = StringCalculator.Add(numbers);
            Assert.AreEqual(0,
                            result);
        }

        [Test]
        public void TestAddWithSingleNumberInStringReturnsTheNumber()
        {
            string numbers = "1";
            int result = StringCalculator.Add(numbers);
            Assert.AreEqual(1,
                            result);
        }

        [TestCase("1,2,3,4,5,6,7,8,9,10")]
        public void TestAddWithMultipleNumbersInStringReturnsTheTotal(string inputNumbers)
        {
            int result = StringCalculator.Add(inputNumbers);
            Assert.AreEqual(55,
                            result);
        }

        [TestCase("1,2,3,4,5\n6,7,8\n9,10")]
        public void TestAddWithMultipleNumbersInStringSplitWithNewLinesAndCommasReturnsTheTotal(string inputNumbers)
        {
            int result = StringCalculator.Add(inputNumbers);
            Assert.AreEqual(55,
                            result);
        }

        [TestCase("1,2,3,4,\n6,7,\n9,10")]
        public void TestAddWithMultipleNumbersInStringReturnZeroForEmptyNumbers(string inputNumbers)
        {
            int result = StringCalculator.Add(inputNumbers);
            Assert.AreEqual(42,
                            result);
        }

        [TestCase("//;\n1;2")]
        public void TestAddWithMultipleNumbersInStringUsingDifferentDelimeter(string inputNumbers)
        {
            int result = StringCalculator.Add(inputNumbers);
            Assert.AreEqual(3,
                            result);
        }

        [TestCase("//;\n1;-2")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddWithNegativeNumbersWillThrowException(string inputNumbers)
        {
            int result = StringCalculator.Add(inputNumbers);
            Assert.AreEqual(3,
                            result);
        }
    }
}
