using System.Diagnostics;
using System.Threading;
void Method()
{
    int x = 500;

    // Список для хранения времени выполнения каждого потока
    List<int> executionTimes = [];
    Thread[] threads = new Thread[10];
    // Запускаем 10 потоков
    for (int i = 0; i < 10; i++)
    {
        // Создаем новый поток
        threads[i] = new(() =>
        {
            // Измеряем время выполнения метода
            Stopwatch stopwatch = new();
            stopwatch.Start();

            // Вызываем метод для генерации, сортировки и подсчета
            int count = ProcessArray(x);

            stopwatch.Stop();

            // Добавляем время выполнения в список
            executionTimes.Add(stopwatch.Elapsed.Milliseconds);

            // Выводим результат для текущего потока
            Console.WriteLine($"Количество элементов, равных {x}: {count}, Время выполнения: {stopwatch.Elapsed.Milliseconds}");
        });

        // Запускаем поток
        threads[i].Start();
    }

    // Ожидаем завершения всех потоков
    foreach (Thread thread in threads)
    {
        thread.Join();
    }

    // Вычисляем минимальное, максимальное и среднее время выполнения
    int minTime = executionTimes.Min();
    int maxTime = executionTimes.Max();
    double averageTime = executionTimes.Sum() / executionTimes.Count;

    // Выводим результаты
    Console.WriteLine($"\nМинимальное время выполнения: {minTime}");
    Console.WriteLine($"Максимальное время выполнения: {maxTime}");
    Console.WriteLine($"Среднее время выполнения: {averageTime}");
}
static int ProcessArray(int x)
{
    // Генерация случайного размера массива
    Random random = new();
    int arraySize = random.Next(10000000, 15000001);

    // Генерация массива случайных чисел
    int[] array = Enumerable.Range(0, arraySize).Select(i => random.Next(1001)).ToArray();

    // Сортировка массива по возрастанию
    Array.Sort(array);

    // Подсчет элементов, равных x
    int count = array.Count(element => element == x);

    return count;
}
Method();