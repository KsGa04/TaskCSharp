using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace TaskCSharp
{
    public class Tasks1_5
    {
        /// <summary>
        /// Task 2
        /// </summary>
        public bool CheckValidCharacters(string input)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
            return input.All(c => allowedCharacters.Contains(c));
        }

        public string GetInvalidCharacters(string input)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
            return new string(input.Where(c => !allowedCharacters.Contains(c)).Distinct().ToArray());
        }
        /// <summary>
        /// Task 1
        /// </summary>
        public string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Task 3
        /// </summary>
        public Dictionary<char, int> GetCharacterCount(string input)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
            return charCount;
        }
        /// <summary>
        /// Task 4
        /// </summary>
        public string FindMaxVowelSubstring(string input)
        {
            string vowels = "aeiouy";
            int maxSubstringLength = 0;
            string maxSubstring = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (vowels.Contains(input[j]))
                        {
                            int substringLength = j - i + 1;
                            if (substringLength > maxSubstringLength)
                            {
                                maxSubstringLength = substringLength;
                                maxSubstring = input.Substring(i, substringLength);
                            }
                        }
                    }
                }
            }

            return maxSubstring;
        }
        /// <summary>
        /// Task 5
        /// </summary>
        public void QuickSort(IList<char> array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        public int Partition(IList<char> array, int left, int right)
        {
            char pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        public void Swap(IList<char> array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public IList<char> TreeSort(IList<char> array)
        {
            var root = new Node(array[0]);

            for (int i = 1; i < array.Count; i++)
            {
                InsertNode(root, array[i]);
            }

            var sortedList = new List<char>();
            InOrderTraversal(root, sortedList);

            return sortedList;
        }

        public void InsertNode(Node root, char character)
        {
            if (root == null)
                return;

            if (character < root.Value)
            {
                if (root.Left == null)
                    root.Left = new Node(character);
                else
                    InsertNode(root.Left, character);
            }
            else
            {
                if (root.Right == null)
                    root.Right = new Node(character);
                else
                    InsertNode(root.Right, character);
            }
        }

        public void InOrderTraversal(Node node, List<char> sortedList)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, sortedList);
                sortedList.Add(node.Value);
                InOrderTraversal(node.Right, sortedList);
            }
        }
    }
}
