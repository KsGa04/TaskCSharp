using NUnit.Framework;

namespace TaskCSharp.Tests
{
    [TestFixture]
    public class UnitTestTask4
    {
        [Test]
        public void FindMaxVowelSubstring_InputIsNull_ReturnsEmptyString()
        {
            // Arrange
            string input = null;
            var instance = new Tasks1_5();

            // Act
            string result = instance.FindMaxVowelSubstring(input);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void FindMaxVowelSubstring_InputIsEmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = string.Empty;
            var instance = new Tasks1_5();

            // Act
            string result = instance.FindMaxVowelSubstring(input);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void FindMaxVowelSubstring_InputDoesNotContainVowels_ReturnsEmptyString()
        {
            // Arrange
            string input = "123456";
            var instance = new Tasks1_5();

            // Act
            string result = instance.FindMaxVowelSubstring(input);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void FindMaxVowelSubstring_InputContainsSingleVowel_ReturnsThatVowel()
        {
            // Arrange
            string input = "hello";
            var instance = new Tasks1_5();

            // Act
            string result = instance.FindMaxVowelSubstring(input);

            // Assert
            Assert.AreEqual("ello", result);
        }

        [Test]
        public void FindMaxVowelSubstring_InputContainsMultipleVowelSubstrings_ReturnsLongestVowelSubstring()
        {
            // Arrange
            string input = "idasus";
            var instance = new Tasks1_5();

            // Act
            string result = instance.FindMaxVowelSubstring(input);

            // Assert
            Assert.AreEqual("idasu", result);
        }
    }
}