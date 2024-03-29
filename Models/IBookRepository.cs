namespace UserLibrary.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> GetBookByTitle(string title);
        IEnumerable<Book> GetBookByAuthor(string name);
        void AddBook(Book book);
        void UpdateBook(int bookId, string? title, string? author, int? year, string? genre);
        void DeleteBook(int bookId);
    }
}
