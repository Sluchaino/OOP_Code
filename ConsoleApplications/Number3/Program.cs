int size;
if(int.TryParse(Console.ReadLine(), out size))
{
    int[] a = new int[size];
    Random random = new();
    Console.WriteLine("Наш массив");
    for(int i = 0; i < size; i++)
    {
        a[i] = random.Next(0, size+1);
        Console.WriteLine($"a[{i}] = {a[i]}");
    }
    Array.Sort(a);
    Console.WriteLine("Наш массив после сортировки");
    for (int i = 0; i < size; i++)
    {
        Console.WriteLine($"a[{i}] = {a[i]}");
    }
    if (a.Length % 2 != 0)
        Console.WriteLine(a[a.Length / 2]);
    else
    {
        Console.WriteLine();
        int index = a.Length / 2;
        double median = (a[index - 1] + a[index]) / 2.0;
        Console.WriteLine(median);
    }
}
else
{
    Console.WriteLine("Не число");
}