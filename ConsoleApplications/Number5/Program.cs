abstract class AbstractClass
{
    public abstract void AMethod();
    public virtual void VMethod()
    { 
        Console.WriteLine("Вызван виртуальный метод из базового класса"); 
    }
}
class First : AbstractClass
{
    public override void AMethod() {}
    public override void VMethod() { }
}
class Program
{
    static void Main(string[] args)
    {
        First first = new();
        first.AMethod();
        first.VMethod();
    }
}