namespace PrintingPatterns
{
    /*
        ____1
        ___2 2
        __3 3 3
        _4 4 4 4
        5 5 5 5 5
     */
    internal class EvenNumberTree : IPatternPrinter
    {
        public void Print()
        {
            int height = 5;

            for (int i = 0; i < height; i++)
            {
                // Print spaces
                for (int k = 0; k < height - 1 - i; k++)
                {
                    Console.Write(" ");
                }

                // Print nums
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write($"{i + 1} ");
                }

                Console.WriteLine();
            }
        }
    }
}
