namespace PrintingPatterns
{
    /*
    ____*____
    ___***___
    __*****__
    _*******_
    *********

    nth_odd = 2(n) - 1, where n > 0
    nRows = treeHeight
    nCols = 2(nRows) - 1

            1
           2 2
          3 3 3
         4 4 4 4
        5 5 5 5 5 
     */
    internal class ChristmasTree : IPatternPrinter
    {
        public void Print()
        {
            int treeHeight = 5;
            int nCols = (2 * treeHeight - 1);
            for (int i = 1; i <= treeHeight; i++)
            {
                for (int j = 1; j <= nCols; j++)
                {
                    int numStars = 2 * i - 1;
                    int numSpace = nCols - numStars;
                    Console.Write("_");
                }

                Console.WriteLine();
            }
        }
    }
}
