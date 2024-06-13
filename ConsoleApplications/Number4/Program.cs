class Base
{
    public string? Str {  get; set; }
    public bool Bool { get; set; }
    public Base(string Str, bool Bool) 
    { 
        this.Str = Str;
        this.Bool = Bool;
    }
}

class A : Base
{
    public A(string Str, bool Bool) : base(Str, Bool)
    {

    }
}

class Program
{
    static void Main(string[] args)
    {
        int size;
        if(int.TryParse(Console.ReadLine(), out size))
        {
            A[] arr1 = new A[size];
            A[] arr2 = new A[size];
            Random random = new Random();
            for(int i = 0; i < size; i++)
            {
                arr1[i] = new($"{i}", Convert.ToBoolean(random.Next(0,2)));
                arr2[i] = new($"{i}", Convert.ToBoolean(random.Next(0, 2)));
            }
            int arr1False = GetCountFalse(arr1);
            int arr2False = GetCountFalse(arr2);
            if (arr1False > arr2False)
                Console.WriteLine($"В первом массиве больше {arr1False}");
            else if (arr1False > arr2False)
                Console.WriteLine($"Во втором массиве больше {arr2False}");
            else Console.WriteLine("Одиннаково");
        }
    }
    static int GetCountFalse(A[] arr)
    {
        int count = 0;
        for(int i = 0;i < arr.Length;i++)
        {
            if (!arr[i].Bool)
            {
                ++count;
            }
        }
        return count;
    }
}

