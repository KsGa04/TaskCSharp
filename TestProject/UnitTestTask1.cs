using NUnit.Framework;
namespace TaskCSharp.Tests
{
    [TestFixture]
    public class UnitTestTask1
    {
        [Test]
        public void ReverseString_InputIsNull_ReturnsEmptyString()
        {
            string input = null;
            var instance = new Tasks1_5();
            string result = instance.ReverseString(input);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ReverseString_InputIsEmptyString_ReturnsEmptyString()
        {
            string input = string.Empty;
            var instance = new Tasks1_5();
            string result = instance.ReverseString(input);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ReverseString_InputIsSingleCharacter_ReturnsSameCharacter()
        {
            string input = "a";
            var instance = new Tasks1_5();
            string result = instance.ReverseString(input);
            Assert.AreEqual("a", result);
        }

        [Test]
        public void ReverseString_InputIsNotEmptyString_ReturnsReversedString()
        {
            string input = "hello";
            var instance = new Tasks1_5();
            string result = instance.ReverseString(input);
            Assert.AreEqual("olleh", result);
        }
    }
}