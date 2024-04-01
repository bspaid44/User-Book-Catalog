namespace UserLibrary.Models
{
    public interface IUserBooksRepository
    {
        IEnumerable<UserBooks> UserBookList { get; }
    }
}
