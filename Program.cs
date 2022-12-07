using Bookish.DataAccess;

namespace Bookish.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var repo = new BookRepository();
            var books = repo.GetAllBooks();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }
}
