namespace UserLibrary.Models
{
    public static class DbInitializer
    {
        internal static void Initialize(IApplicationBuilder applicationBuilder)
        {
            UserLibraryDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserLibraryDbContext>();
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, Genre = "Fiction" },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960, Genre = "Fiction" },
                new Book { Title = "1984", Author = "George Orwell", Year = 1949, Genre = "Fiction" },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Genre = "Fiction" },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = 1951, Genre = "Fiction" },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937, Genre = "Fantasy" },
                new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Year = 1954, Genre = "Fantasy" },
                new Book { Title = "The Da Vinci Code", Author = "Dan Brown", Year = 2003, Genre = "Mystery" },
            };

            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
        }
    }
}
