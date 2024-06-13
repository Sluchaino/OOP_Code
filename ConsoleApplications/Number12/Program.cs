using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
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
            // Добавление новой записи
            var myData = new MyData { Key = 1, Value = $"Запись номер {1}" };
            dbContext.MyData.Add(myData);

            // Сохранение изменений в базе данных
            dbContext.SaveChanges();

            Console.WriteLine("Запись успешно добавлена в базу данных.");

            Console.WriteLine(dbContext.MyData.First<MyData>().Value);
        }
    }
}