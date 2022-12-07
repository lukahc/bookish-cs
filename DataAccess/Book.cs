namespace Bookish.DataAccess;

public class Book
{
    public int Isbn;
    public string Title;
    public string Author;
    public int TotalCopies;
    private readonly BookRepository _repo = new();
    public int AvailableCopies;

    public Book(int isbn, string title, string author, int totalCopies)
    {
        this.Isbn = isbn;
        this.Title = title;
        this.Author = author;
        this.TotalCopies = totalCopies;
        this.AvailableCopies = totalCopies - _repo.GetTotalBorrowed(isbn).Count();
    }
}
