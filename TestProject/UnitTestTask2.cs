using NUnit.Framework;
using System.Linq;

namespace TaskCSharp.Tests
{
    [TestFixture]
    public class UnitTestTask2
    {
        [Test]
        public void CheckValidCharacters_InputIsNull_ReturnsFalse()
        {
            // Arrange
            string input = null;
            var instance = new Tasks1_5();

            // Act
            bool result = instance.CheckValidCharacters(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckValidCharacters_InputIsEmptyString_ReturnsFalse()
        {
            // Arrange
            string input = string.Empty;
            var instance = new Tasks1_5();

            // Act
            bool result = instance.CheckValidCharacters(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckValidCharacters_InputContainsOnlyValidCharacters_ReturnsTrue()
        {
            // Arrange
            string input = "abcde";
            var instance = new Tasks1_5();

            // Act
            bool result = instance.CheckValidCharacters(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckValidCharacters_InputContainsInvalidCharacters_ReturnsFalse()
        {
            // Arrange
            string input = "abcd123";
            var instance = new Tasks1_5();

            // Act
            bool result = instance.CheckValidCharacters(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetInvalidCharacters_InputIsNull_ReturnsEmptyString()
        {
            // Arrange
            string input = null;
            var instance = new Tasks1_5();

            // Act
            string result = instance.GetInvalidCharacters(input);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetInvalidCharacters_InputIsEmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = string.Empty;
            var instance = new Tasks1_5();

            // Act
            string result = instance.GetInvalidCharacters(input);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetInvalidCharacters_InputContainsOnlyValidCharacters_ReturnsEmptyString()
        {
            // Arrange
            string input = "abcde";
            var instance = new Tasks1_5();

            // Act
            string result = instance.GetInvalidCharacters(input);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetInvalidCharacters_InputContainsInvalidCharacters_ReturnsInvalidCharacters()
        {
            // Arrange
            string input = "abcd123";
            var instance = new Tasks1_5();

            // Act
            string result = instance.GetInvalidCharacters(input);

            // Assert
            Assert.AreEqual("123", result);
        }
    }
}