using InterviewTests;

namespace InterviewPracticeCode
{
    public class LargestPalidromeProduct
    {
        public static double GetLargestPalindromeProduct(int numDigits)
        {
            double currentMax = 0;
            double startVal = Math.Pow(10, numDigits - 1);
            double endVal = Math.Pow(10, numDigits);

            for (double i = startVal; i < endVal; i++)
                for (double j = startVal; j < endVal; j++)
                {
                    double prod = i * j;
                    if (prod > currentMax && Palindrome.IsPalidrome(prod.ToString()))
                        currentMax = prod;
                }

            return currentMax;
        }
    }
}
