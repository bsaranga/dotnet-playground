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
            IPatternPrinter evenNumTree = new EvenNumberTree();
            
            christmasTree.Print();
            
            Console.WriteLine();

            evenNumTree.Print();
        }
    }
}
