using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Models;
using UserLibrary.ViewModels;

namespace UserLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult Index()
        {
            IEnumerable<Book> books = _bookRepository.Books.OrderBy(b => b.Title);
            return View(new BookIndexViewModel(books));
        }

        public IActionResult Details(int id)
        {
            return View(_bookRepository.Books.FirstOrDefault(b => b.BookId == id));
        }

        public IActionResult Search()
        {
            return View();
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult Create(Book book)
        {
            _bookRepository.AddBook(book);
            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToActionResult Update(int bookId, string? title, string? author, int? year, string? genre)
        {
            _bookRepository.UpdateBook(bookId, title, author, year, genre);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public RedirectToActionResult Delete(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
            return RedirectToAction("Index");
        }
    }
}
