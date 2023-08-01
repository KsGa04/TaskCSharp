using Microsoft.AspNetCore.Mvc;

namespace TaskCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskCSharp : ControllerBase
    {
        [HttpGet("{inputString}")]
        public ActionResult<string> ManipulateString(string inputString)
        {
            if (!CheckValidCharacters(inputString))
            {
                return BadRequest("Invalid characters: " + GetInvalidCharacters(inputString));
            }

            string result = "";

            if (inputString.Length % 2 == 0)
            {
                int halfLength = inputString.Length / 2;
                string firstHalf = inputString.Substring(0, halfLength);
                string secondHalf = inputString.Substring(halfLength);
                string reversedFirstHalf = ReverseString(firstHalf);
                string reversedSecondHalf = ReverseString(secondHalf);
                result = reversedFirstHalf + reversedSecondHalf;
            }
            else
            {
                string reversedInputString = ReverseString(inputString);
                result = reversedInputString + inputString;
            }
            Dictionary<char, int> charCount = GetCharacterCount(result);
            string maxVowelSubstring = FindMaxVowelSubstring(result);
            return $"Processed string: {result}\nCharacter count: {string.Join("\n", charCount.Select(c => $"{c.Key}: {c.Value}"))} \nMax Vowel Substring: {maxVowelSubstring}";
        }
        /// <summary>
        /// Task 2
        /// </summary>
        private bool CheckValidCharacters(string input)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
            return input.All(c => allowedCharacters.Contains(c));
        }

        private string GetInvalidCharacters(string input)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
            return new string(input.Where(c => !allowedCharacters.Contains(c)).Distinct().ToArray());
        }
        /// <summary>
        /// Task 1
        /// </summary>
        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Task 3
        /// </summary>
        private Dictionary<char, int> GetCharacterCount(string input)
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
        private string FindMaxVowelSubstring(string input)
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
    }
}