class A
{ 
    public int Number {  get; set; }
    public string String { get; set; }
    public A(int number, string str)
    {
        Number = number;
        String = str;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int size = Convert.ToInt32(Console.ReadLine());
        A[] arr = new A[size];
        for(int i = 0; i < size; i++)
        {
            arr[i] = new(i, $"{i}");
        }
        foreach (A a in arr)
            Console.WriteLine($"Number - {a.Number}, String - {a.String}");
    }
}

