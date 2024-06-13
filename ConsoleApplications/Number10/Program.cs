interface IMyInterface
{
    void Meyhod1();
    void Meyhod2();
    void Meyhod3();
}

class MyClass : IMyInterface
{
    public void Meyhod1(){}

    public void Meyhod2() {}

    public void Meyhod3() {}
}

class Program
{
    static void Main(string[] args)
    {
        IMyInterface myInterface = new MyClass();
        myInterface.Meyhod1();
        myInterface.Meyhod2();
        myInterface.Meyhod3();
    }
}