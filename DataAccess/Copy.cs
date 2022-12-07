namespace Bookish.DataAccess;

public class Copy
{
    public int CopyId;
    public int UserId;
    public Book Book;
    public string ReturnDate;
    private readonly BookRepository _repo = new();

    public Copy(int copyId, int userId, int isbn, string returnDate)
    {
        this.CopyId = copyId;
        this.UserId = userId;
        this.Book = _repo.GetBookByIsbn(isbn);
        this.ReturnDate = returnDate;
    }
}
