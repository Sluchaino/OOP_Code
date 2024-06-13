using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

class MyData
{
    [Key]
    public int Key { get; set; }
    public string? Value { get; set; }
}

class ApplicationDBContext : DbContext
{
    public DbSet<MyData> MyData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydatabase.db");
    }
}
class Program
{
    static void Main(string[] args)
    {
        using (var dbContext = new ApplicationDBContext())
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var a = dbContext.MyData.ToArray().Length + 1;
            // Добавление новой записи
            for(int i = 0; i < 1000000; i++) 
            { 
                var myData = new MyData { Key = i + 1, Value = $"Запись номер {i + 1}" };
                dbContext.MyData.Add(myData);
            }

            // Сохранение изменений в базе данных
            dbContext.SaveChanges();

            Console.WriteLine("Записи успешно добавлены в базу данных.");
        }
        using (var dbContext = new ApplicationDBContext())
        {
            Stopwatch stopwatch = new();
            int totalMilliseconds = 0;
            int numberOfSearches = 1000;
            Random random = new Random();
            // Производим 1000 операций поиска по ключу и суммируем время
            for (int i = 0; i < numberOfSearches; i++)
            {
                int searchKey = random.Next(1000000); // Генерируем случайный ключ

                stopwatch.Restart();
                var result = dbContext.MyData.FirstOrDefault(item => item.Key == searchKey);
                stopwatch.Stop();

                totalMilliseconds += stopwatch.Elapsed.Milliseconds;
            }

            double averageTimeForKeySearch = (double)totalMilliseconds / numberOfSearches;

            Console.WriteLine($"Среднее время поиска по ключу: {averageTimeForKeySearch} мс");

            // Производим 1000 операций поиска по значению и суммируем время
            totalMilliseconds = 0;
            for (int i = 0; i < numberOfSearches; i++)
            {
                string searchValue = $"Запись номер {random.Next(1000000)}"; // Генерируем случайное значение

                stopwatch.Restart();
                var result = dbContext.MyData.FirstOrDefault(item => item.Value == searchValue);
                stopwatch.Stop();

                totalMilliseconds += stopwatch.Elapsed.Milliseconds;
            }

            double averageTimeForValueSearch = (double)totalMilliseconds / numberOfSearches;

            Console.WriteLine($"Среднее время поиска по значению: {averageTimeForValueSearch} мс");
        }
    }
}