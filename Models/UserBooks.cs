namespace UserLibrary.Models
{
    public class UserBooks
    {
        public string UserBooksId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
