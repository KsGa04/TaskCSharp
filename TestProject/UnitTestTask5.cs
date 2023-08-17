using NUnit.Framework;
using System.Collections.Generic;

namespace TaskCSharp.Tests
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void QuickSort_InputIsEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            var array = new List<char>();
            var instance = new Tasks1_5();

            // Act
            instance.QuickSort(array, 0, array.Count - 1);

            // Assert
            Assert.AreEqual(0, array.Count);
        }

        [Test]
        public void QuickSort_InputIsArrayInDescendingOrder_ReturnsArrayInAscendingOrder()
        {
            // Arrange
            var array = new List<char> { 'd', 'c', 'b', 'a' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };
            var instance = new Tasks1_5();

            // Act
            instance.QuickSort(array, 0, array.Count - 1);

            // Assert
            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void TreeSort_InputIsEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            var array = new List<char>();
            var instance = new Tasks1_5();

            // Act
            var result = instance.TreeSort(array);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void TreeSort_InputIsArrayInDescendingOrder_ReturnsArrayInAscendingOrder()
        {
            // Arrange
            var array = new List<char> { 'd', 'c', 'b', 'a' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };
            var instance = new Tasks1_5();

            // Act
            var result = instance.TreeSort(array);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
