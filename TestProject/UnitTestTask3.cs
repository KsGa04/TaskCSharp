using NUnit.Framework;
using System.Collections.Generic;

namespace TaskCSharp.Tests
{
    [TestFixture]
    public class UnitTestTask3
    {
        [Test]
        public void GetCharacterCount_InputIsNull_ReturnsEmptyDictionary()
        {
            // Arrange
            string input = null;
            var instance = new Tasks1_5();

            // Act
            Dictionary<char, int> result = instance.GetCharacterCount(input);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetCharacterCount_InputIsEmptyString_ReturnsEmptyDictionary()
        {
            // Arrange
            string input = string.Empty;
            var instance = new Tasks1_5();

            // Act
            Dictionary<char, int> result = instance.GetCharacterCount(input);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetCharacterCount_InputContainsOnlyOneCharacter_ReturnsDictionaryWithOneElement()
        {
            // Arrange
            string input = "a";
            var instance = new Tasks1_5();

            // Act
            Dictionary<char, int> result = instance.GetCharacterCount(input);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result['a']);
        }

        [Test]
        public void GetCharacterCount_InputContainsMultipleCharacters_ReturnsCorrectCharCountDictionary()
        {
            // Arrange
            string input = "hello";
            var instance = new Tasks1_5();

            // Act
            Dictionary<char, int> result = instance.GetCharacterCount(input);

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result['h']);
            Assert.AreEqual(1, result['e']);
            Assert.AreEqual(2, result['l']);
            Assert.AreEqual(1, result['o']);
        }
    }
}