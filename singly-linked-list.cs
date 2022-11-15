using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var singlyLinkedList = new SinglyLinkedList<char>();
        singlyLinkedList.Append('f');
        singlyLinkedList.Append('a');
        singlyLinkedList.Append('b');
        singlyLinkedList.Append('i');
        singlyLinkedList.Append('a');
        singlyLinkedList.Append('n');
        Console.WriteLine(singlyLinkedList.Print(new MyPrinter<char>()));
        Console.WriteLine(singlyLinkedList.Count);
    }
}

sealed class Node<T>
{
    public Node<T> Next { get; set; }
    private T data { get; set; }

    public Node(T value)
    {
        data = value;
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }
}

sealed class SinglyLinkedList<T>
{
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }
    public int Count { get; private set; }

    public void Append(T value)
    {
        if (Head == null)
        {
            Head = new Node<T>(value);
            Tail = Head;
        }
        else
        {
            Tail.Next = new Node<T>(value);
            Tail = Tail.Next;
        }
        Count++;
    }

    public string Print(IPrintable<T> printable)
    {
        return printable.ToString(Head);
    }
}

interface IPrintable<T>
{
    string ToString(Node<T> node);
}

class MyPrinter<T> : IPrintable<T>
{
    public string ToString(Node<T> node)
    {
        var result = new StringBuilder();
        while (node != null)
        {
            result.Append(node.Data);
            node = node.Next;
        }
        return result.ToString();
    }
}
