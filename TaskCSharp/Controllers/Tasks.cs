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

            return result;
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}