namespace LinkedList;

public static class Program
{
    static void Main()
    {
        LinkedList<int> ls = new LinkedList<int>();
        ls.PushBack(5);
        ls.PushBack(3);
        ls.PushBack(6);

        Console.Write("Initial list: ");
        PrintList(ls);


        for (Node<int>? cur = ls.Begin(); cur != ls.End();)
        {
            cur = cur?.Data == 3 ? ls.Erase(cur) : cur?.Next;
        }

        Console.Write("After erasing 3: ");
        PrintList(ls);

        for (Node<int>? cur = ls.Begin(); cur != ls.End(); cur = cur?.Next)
        {
            if (cur?.Data == 6 || cur?.Data == 5)
            {
                Node<int> newNode = new Node<int>(7);
                ls.InsertBefore(newNode, cur);
            }
        }

        Console.Write("After inserting before 6 and 5: ");
        PrintList(ls);

        Console.WriteLine($"first of 6: {ls.FirstOf(6)}");

        Console.WriteLine($"Get at pos 3 is: {ls.GetAtPos(3)?.Data}");

        Console.WriteLine($"first of 8 is: {ls.FirstOf(8)}");

        Console.WriteLine($"list size is: {ls.Size()}");
    }

    private static void PrintList<T>(LinkedList<T> ls)
    {
        for (Node<T>? cur = ls.Begin(); cur != ls.End(); cur = cur?.Next)
        {
            Console.Write($"{cur!.Data} ");
        }

        Console.WriteLine();
    }
}