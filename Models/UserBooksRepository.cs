namespace UserLibrary.Models
{
    public class UserBooksRepository : IUserBooksRepository
    {
        private UserLibraryDbContext context;
        public UserBooksRepository(UserLibraryDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<UserBooks> UserBookList => context.UserBooks;
    }
}
