using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Models;

namespace UserLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly UserLibraryDbContext _db;

        public SearchController(UserLibraryDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [HttpPost]
        public IActionResult SearchBooks([FromBody] string title)
        {
            var books = _db.Books.Where(b => b.Title.Contains(title));
            if (books == null)
            {
                return NotFound();
            }
            return new JsonResult(books);
        }
    }
}
