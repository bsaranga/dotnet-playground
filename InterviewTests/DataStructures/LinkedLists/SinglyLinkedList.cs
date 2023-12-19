namespace InterviewPracticeCode.DataStructures.LinkedLists
{
    internal class Node<T>
    {
        public T Value;
        public Node<T>? Next;
        
        public Node(T Value)
        {
            this.Value = Value;
        }

        public Node(T Value, Node<T>? Next)
        {
            this.Value = Value;
            this.Next = Next;
        }
    }

    public class SinglyLinkedList<T>
    {
        private int Count = 0;
        private Node<T>? Head;
        private Node<T>? Tail;

        public void Push(T Value)
        {
            var node = new Node<T>(Value, Head);
            Head = node;
            if (Count == 0)
                Tail = node;

            Count++;
        }

        public T? Pop()
        {
            if (Count == 0)
                return default(T?);
            
            T currenVal = Head!.Value;
            
            Head = Head.Next;
            Count--;
            if (Count == 0)
                Tail = null;

            return currenVal;
        }

        public void Add(T Value)
        {
            var node = new Node<T>(Value);
            if (Count == 0)
                Head = node;
            else Tail!.Next = node;

            Tail = node;
            Count++;
        }

        public override string? ToString()
        {
            string rep = "{ ";
            if (Count == 0)
            {
                rep += "}";
                return rep;
            } else
            {
                int k = 0;
                var currentNode = Head;
                while (k < Count && currentNode!.Value != null)
                {
                    rep += $"{currentNode.Value}";
                    rep += (k != Count - 1) ? ", " : " ";
                    currentNode = currentNode.Next;
                    k++;
                }

                rep += "}";
                return rep;
            }
        }
    }
}
