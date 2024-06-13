class Base
{
    public int Number { get; set; }
    public string Name { get; set; }
    public Base(int  number, string name)
    {
        Number = number;
        Name = name;
    }
}
class MyClass : Base
{
    public MyClass(int  number, string name) : base(number, name) { }
}


class MyClassGeneric<T> where T : Base
{

}

class Program
{ 
    static void Main(string[] args)
    {
        MyClassGeneric<MyClass> myClassGeneric = new();
    }
}
