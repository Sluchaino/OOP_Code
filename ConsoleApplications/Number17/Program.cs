void Method()
{
    while(true)
    {
        // Ожидаем нажатие Enter
        Console.ReadLine();

        // Выводим сообщение на консоль
        Console.WriteLine("Enter был нажат!");
    }
}
void Main()
{
    Thread thread = new(Method);
    thread.Start();
}
Main();