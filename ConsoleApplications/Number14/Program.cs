using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
class Author
{
    [Key]
    public int? AuthorId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book>? Books { get; set; }
}
class Book
{
    [Key]
    public int? BookId { get; set; }

    public string? Title { get; set; }

    public int? AuthorId { get; set; }
    public virtual Author? Author { get; set; }
}

class ApplicationDBContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

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
            var Author = new Author { AuthorId = 1, Name = $"Author 1" };
            dbContext.Authors.Add(Author);
            dbContext.SaveChanges();

            Book book1 = new() { Title = "Book 1", AuthorId = Author.AuthorId };
            Book book2 = new() { Title = "Book 2", AuthorId = Author.AuthorId };
            dbContext.Books.AddRange(book1, book2);
            dbContext.SaveChanges();

            Console.WriteLine("Запись успешно добавлена в базу данных.");

            var authorsWithBooks = dbContext.Authors.ToList();
            foreach (var a in authorsWithBooks)
            {
                Console.WriteLine($"Автор: {a.Name}");
                if(a.Books != null)
                {
                    foreach (var b in a.Books)
                    {
                        Console.WriteLine($" - Книга: {b.Title}");
                    }
                }
                
            }
        }
    }
}