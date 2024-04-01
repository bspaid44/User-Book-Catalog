using System.ComponentModel.DataAnnotations;

namespace UserLibrary.Models
{
    public class UserBooks
    {
        public int Id { get; set; }
        public string UserBooksId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
