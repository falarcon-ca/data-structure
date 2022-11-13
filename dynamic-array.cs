internal class Program
{
    private static void Main(string[] args)
    {
        var dynamicArray = new DynamicArray<string>(3);
        dynamicArray.Insert("d");
        dynamicArray.Insert("a");
        dynamicArray.Insert("t");
        dynamicArray.Insert("a");
        dynamicArray.RemoveAt(2);
        dynamicArray.Insert("2");
        dynamicArray.Print();
    }
}

public class DynamicArray<T>
{
    private T[] data;
    private int lastIndex;

    public DynamicArray(int size)
    {
        data = new T[size];
    }

    public void Insert(T value)
    {
        if (data.Length == lastIndex)
        {
            var newData = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }
        data[lastIndex++] = value;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= lastIndex)
        {
            throw new Exception("Invalid index");
        }
        for (int i = index; i < data.Length - 1; i++)
        {
            data[i] = data[i + 1];
        }
        lastIndex--;
    }

    public void Print()
    {
        for (int i = 0; i < lastIndex; i++)
        {
            Console.WriteLine(data[i]);
        }
    }
}
