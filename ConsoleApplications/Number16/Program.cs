using System.Diagnostics;
using System.Threading;
static int ProcessArray(int x, object locker, out int time)
{
    int count = 0;
    // Генерация случайного размера массива
    Random random = new();
    int arraySize = random.Next(10000000, 15000001);

    // Генерация массива случайных чисел
    int[] array = Enumerable.Range(0, arraySize).Select(i => random.Next(1001)).ToArray();

    // Сортировка массива по возрастанию
    Array.Sort(array);
    Stopwatch stopwatch = new();
    stopwatch.Start();
    lock (locker)
    {
        stopwatch.Stop();
        time = stopwatch.Elapsed.Milliseconds;
        count = array.Count(element => element == x);
        // Подсчет элементов, равных x
    }
    return count;
    
}
void Method1()
{
    int x = 500;
    List<int> executionTimes = [];
    Thread[] threads = new Thread[10];
    object locker = new();
    for (int i = 0; i < 10; i++)
    {
        int count = 0;
        int time = 0;
        threads[i] = new(() =>
        {
            
            count = ProcessArray(x, locker, out time);
            if(time != 0)
                executionTimes.Add(time);

            // Выводим результат для текущего потока
            Console.WriteLine($"Количество элементов, равных {x}: {count}, Время выполнения: {time}");
        });

        // Запускаем поток
        threads[i].Start();
    }
    foreach (Thread thread in threads)
    {
        thread.Join();
    }
    int minTime = executionTimes.Min();
    int maxTime = executionTimes.Max();
    double averageTime = executionTimes.Sum() / executionTimes.Count;

    // Выводим результаты
    Console.WriteLine($"\nМинимальное время выполнения: {minTime}");
    Console.WriteLine($"Максимальное время выполнения: {maxTime}");
    Console.WriteLine($"Среднее время выполнения: {averageTime}");
}
Method1();