using UserLibrary.Models;

namespace UserLibrary.ViewModels
{
    public class BookIndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public BookIndexViewModel(IEnumerable<Book> books)
        {
            Books = books;
        }
    }
}
