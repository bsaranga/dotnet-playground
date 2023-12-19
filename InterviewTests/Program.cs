using InterviewPracticeCode.DataStructures.LinkedLists;

namespace InterviewTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sll = new SinglyLinkedList<int?>();

            sll.Add(1);
            sll.Add(2);
            sll.Add(3);
            sll.Add(4);

            Console.WriteLine(sll.ToString());

            Console.ReadLine();
        }
    }
}