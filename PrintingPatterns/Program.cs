namespace PrintingPatterns
{
    public interface IPatternPrinter
    {
        void Print();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPatternPrinter christmasTree = new ChristmasTree();
            christmasTree.Print();
        }
    }
}
