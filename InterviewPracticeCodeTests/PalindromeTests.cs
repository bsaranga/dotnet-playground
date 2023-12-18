using InterviewTests;

namespace InterviewPracticeCodeTests
{
    public class Tests
    {
        [Test]
        [TestCase("radar")]
        [TestCase("level")]
        [TestCase("deified")]
        [TestCase("A man, a plan, a canal, Panama!")]
        [TestCase("Able was I ere I saw Elba")]
        [TestCase("civic")]
        [TestCase("noon")]
        [TestCase("madam")]
        [TestCase("racecar")]
        [TestCase("kayak")]
        [TestCase("refer")]
        [TestCase("rotor")]
        [TestCase("deed")]
        public void Test_Whether_Palindrome(string text)
        {
            bool result = Palindrome.IsPalidrome(text);

            Assert.IsTrue(result);
        }
    }
}