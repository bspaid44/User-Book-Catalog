using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace UserLibrary.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly UserLibraryDbContext _userLibraryDbContext;

        public BookRepository(UserLibraryDbContext userLibraryDbContext)
        {
            _userLibraryDbContext = userLibraryDbContext;
        }

        public IEnumerable<Book> Books => _userLibraryDbContext.Books;

        public void AddBook(Book book)
        {
            _userLibraryDbContext.Books.Add(book);
            _userLibraryDbContext.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            _userLibraryDbContext.Books.Remove(_userLibraryDbContext.Books.FirstOrDefault(b => b.BookId == bookId));
            
            _userLibraryDbContext.SaveChanges();
        }

        public void UpdateBook(int bookId, string? title, string? author, int? year, string? genre)
        {
            var book = _userLibraryDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                if (title != null)
                {
                    book.Title = title;
                }
                if (author != null)
                {
                    book.Author = author;
                }
                if (year != null)
                {
                    book.Year = year;
                }
                if (genre != null)
                {
                    book.Genre = genre;
                }
            }
            _userLibraryDbContext.SaveChanges();
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return _userLibraryDbContext.Books.Where(b => b.Author.Contains(author));
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return _userLibraryDbContext.Books.Where(b => b.Title.Contains(title));
        }

    }
}
