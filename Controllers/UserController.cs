using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Models;
using UserLibrary.ViewModels;

namespace UserLibrary.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserLibraryDbContext _db;

        public UserController(UserLibraryDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            string userBooksId = User.Identity.Name;
            IEnumerable<Book> books = _db.UserBooks.Where(ub => ub.UserBooksId == userBooksId).Select(ub => ub.Book);
            if (books != null)
            {
                return View(new BookIndexViewModel(books));
            }
            return Redirect("~/");
        }


        public RedirectToActionResult AddBook(int bookId)
        {
            string userBooksId = User.Identity.Name;
            var book = _db.Books.Find(bookId);
            if (book != null && userBooksId != null)
            {
                UserBooks userBooks = new UserBooks
                {
                    UserBooksId = userBooksId,
                    Book = book
                };
                _db.UserBooks.Add(userBooks);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
