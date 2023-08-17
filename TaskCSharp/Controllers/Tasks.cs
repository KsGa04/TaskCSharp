using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace TaskCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskCSharp : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BlacklistOptions _blacklist;
        private readonly IConfiguration _configuration;
        private readonly RequestCounterService _requestCounterService;
        public TaskCSharp(IHttpClientFactory httpClientFactory, IOptions<BlacklistOptions> blacklistOptions, IConfiguration configuration, RequestCounterService requestCounterService)
        {
            _httpClientFactory = httpClientFactory;
            _blacklist = blacklistOptions.Value;
            _configuration = configuration;
            _requestCounterService = requestCounterService;
        }

        [HttpGet("{inputString}/{algorithm}")]

        public async Task<ActionResult<string>> ManipulateStringAsync(string inputString, string algorithm)
        {
            bool isSlotAcquired = await _requestCounterService.TryAcquireRequestSlot();
            if (!isSlotAcquired)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
            try
            {
                if (string.IsNullOrEmpty(inputString))
                    return BadRequest("Text is required");

                if (string.IsNullOrEmpty(algorithm))
                    return BadRequest("Algorithm is required");

                foreach (string blacklistedWord in _blacklist.Words)
                {
                    if (string.Equals(blacklistedWord, inputString, StringComparison.OrdinalIgnoreCase))
                    {
                        return BadRequest("The word is blacklisted.");
                    }
                }

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



                char[] characters = result.ToCharArray();

                switch (algorithm.ToLower())
                {
                    case "quicksort":
                        QuickSort(characters, 0, characters.Length - 1);
                        break;
                    case "treesort":
                        characters = TreeSort(characters).ToArray();
                        break;
                    default:
                        return BadRequest("Invalid algorithm");
                }
                string modifiedString = "";
                Random random = new Random();

                try
                {

                    int randomNumber = await GetRandomNumberFromApiAsync(result.Length);
                    if (randomNumber >= result.Length)
                    {
                        return BadRequest("Generated random number is out of bounds.");
                    }
                    modifiedString = result.Remove(randomNumber, 1);
                }
                catch (Exception)
                {
                    int randomNumber = random.Next(result.Length);
                    modifiedString = result.Remove(randomNumber, 1);
                }

                return Ok($"Processed string: {result}\nCharacter count: {string.Join("\n", charCount.Select(c => $"{c.Key}: {c.Value}"))} \nMax Vowel Substring: {maxVowelSubstring} \n Sorted string: {new string(characters)} \n Update string: {modifiedString}");
            }

            finally
            {
                _requestCounterService.ReleaseRequestSlot();
            }
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
        /// <summary>
        /// Task 5
        /// </summary>
        private static void QuickSort(IList<char> array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(IList<char> array, int left, int right)
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

        private static void Swap(IList<char> array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static IList<char> TreeSort(IList<char> array)
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

        private static void InsertNode(Node root, char character)
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

        private static void InOrderTraversal(Node node, List<char> sortedList)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, sortedList);
                sortedList.Add(node.Value);
                InOrderTraversal(node.Right, sortedList);
            }
        }
        //Task 6
        private async Task<int> GetRandomNumberFromApiAsync(int length)
        {
            string apiUrl = _configuration.GetConnectionString("RandomNumberAPI");
            var httpClient = _httpClientFactory.CreateClient();
            //string apiUrl = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&count=1&max={length}";
            var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var randomNumber = await response.Content.ReadAsStringAsync();
            return int.Parse(randomNumber);
        }
    }
}