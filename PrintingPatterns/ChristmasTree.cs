namespace PrintingPatterns
{
    /*
    ____*
    ___***
    __*****
    _*******
    *********
        |

    nth_odd = 2(n) + 1, where n >= 0
    nRows = treeHeight
    nCols = 2(nRows) - 1 
     */
    internal class ChristmasTree : IPatternPrinter
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

                // Print stars
                for (int j = 0; j < (2 * i + 1); j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            // Print trunk
            for (int i = 0;i < height; i++)
            {
                if (i == height - 1)
                {
                    Console.Write("|");
                } else Console.Write(" ");
            }
        }
    }
}
