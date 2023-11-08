namespace InterviewTests
{
    public static class Extensions
    {
        public static void ShowPoint(this Point point)
        {
            Console.WriteLine($"X: {point.pointX}, Y: {point.pointY},");
        }
    }
}
