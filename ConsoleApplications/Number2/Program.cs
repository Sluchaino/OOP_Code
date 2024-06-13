using System.ComponentModel;
using System.Reflection;
class A
{
    private void Method(string str)
    {
        Console.WriteLine($"Значение {str}");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(A);

        MethodInfo methodInfo = type.GetMethod("Method", BindingFlags.NonPublic | BindingFlags.Instance);

        A a = new();

        methodInfo.Invoke(a, new object[] { Console.ReadLine() });
    }
}
