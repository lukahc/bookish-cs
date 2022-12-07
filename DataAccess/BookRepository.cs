using System.Configuration;
using System.Data;
using Dapper;
using Npgsql;

namespace Bookish.DataAccess;

public class BookRepository
{
    private static readonly IDbConnection DB = new NpgsqlConnection(
        ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString
    );

    public IEnumerable<Book> GetAllBooks()
    {
        return DB.Query<Book>("SELECT * FROM bookstable ORDER BY title");
    }

    public Book GetBookByIsbn(int isbn)
    {
        return DB.Query<Book>($"SELECT * FROM bookstable WHERE isbn = {isbn}").AsList()[0];
    }

    public IEnumerable<Book> GetSearchResults(string text)
    {
        return DB.Query<Book>($"SELECT * FROM bookstable WHERE title ~ {text} OR author ~ {text}");
    }

    public IEnumerable<Copy> GetUserBorrowed(int userId)
    {
        return DB.Query<Copy>($"SELECT * FROM booksborrowed WHERE userid = {userId}");
    }

    public IEnumerable<Copy> GetTotalBorrowed(int isbn)
    {
        return DB.Query<Copy>($"SELECT * FROM booksborrowed WHERE isbn = {isbn}");
    }

    public void AddBook(Book newBook)
    {
        DB.Query(
            $"INSERT INTO bookstable(title, author, totalcopies) VALUES ({newBook.Title}, {newBook.Author}, {newBook.TotalCopies})"
        );
    }
}
