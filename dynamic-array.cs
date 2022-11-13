internal class Program
{
    private static void Main(string[] args)
    {
        var dynamicArray = new DynamicArray<string>(3);
        dynamicArray.Insert("d");
        dynamicArray.Insert("a");
        dynamicArray.Insert("t");
        dynamicArray.Insert("a");
        dynamicArray.Print();
    }
}

public class DynamicArray<T>
{
    private T[] data;
    private int counter;
    public DynamicArray(int size)
    {
        data = new T[size];
    }

    public void Insert(T value)
    {
        if (data.Length == counter)
        {
            var newData = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }
        data[counter++] = value;
    }

    public void Print()
    {
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine(data[i]);
        }
    }
}

