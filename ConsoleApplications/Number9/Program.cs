class Program
{
    delegate void MyDelegate1(int num, string str, bool flag);
    delegate int MyDelegate2(int[] numbers, double value);

    static void Method1(int num, string str, bool flag) {;}
    static int Method2(int[] numbers, double value) { return 0; }

    static void Main(string[] args)
    {
        MyDelegate1 delegate1 = Method1;
        MyDelegate2 delegate2 = Method2;

        delegate1.Invoke(5, "5", false);
        delegate2.Invoke([5,7,3,1], 5.1);
    }
}


