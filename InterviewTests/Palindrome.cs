using System.Text.RegularExpressions;

namespace InterviewTests
{
    public class Palindrome
    {
        public static bool IsPalidrome(string text)
        {
            bool isPalindrome = true;
            text = Regex.Replace(text.ToLower().Trim(), "[^a-zA-Z0-9]", "");

            for (int i = 0; i < text.Length/2; i++)
                if (text[i] != text[text.Length - (1 + i)])
                {
                    isPalindrome = false; 
                    break;
                }

            return isPalindrome;
        }
    }
}
