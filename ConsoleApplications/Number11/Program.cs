using System;

class MyClass
{
    public delegate void MyDelegate(int num);
    MyDelegate? myEvent;
    public event MyDelegate MyEvent
    {
        add
        {
            myEvent += value;
            Console.WriteLine($"{value.Method.Name} добавлен");
        }
        remove
        {
            myEvent -= value;
            Console.WriteLine($"{value.Method.Name} удален");
        }
    }
    public void RiseIvent(int num)
    {
        myEvent?.Invoke(num);
    }
}
class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new();
        myClass.MyEvent += MyEvent;
        myClass.RiseIvent(5);
        myClass.MyEvent -= MyEvent;
        myClass.MyEvent += MyEvent1;
        myClass.RiseIvent(5);
    }
   static void MyEvent(int value)
   {
        Console.WriteLine($"Событие произошло! Значение: {value}");
   }
    static void MyEvent1(int value)
    {
        Console.WriteLine($"Событие произошло! Значение: {value}");
    }
}

