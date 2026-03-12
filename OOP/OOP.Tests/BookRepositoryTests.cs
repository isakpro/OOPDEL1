using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP;
using OOP.Repositories;
using Xunit;

namespace OOP.Tests
{
    public class BookRepositoryTests
    {
        private static DbContextOptions<LibraryContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldSaveBookToDatabase()
        {
            var options = CreateNewContextOptions();

            using (var context = new LibraryContext(options))
            {
                var repository = new BookRepository(context);
                var book = new Book("123", "Test", "Author", 2024);

                await repository.AddAsync(book);

                var saved = await context.Books.FirstOrDefaultAsync(b => b.ISBN == "123");
                Assert.NotNull(saved);
                Assert.Equal("Test", saved.Title);
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            var options = CreateNewContextOptions();

            using (var context = new LibraryContext(options))
            {
                context.Books.AddRange(
                    new Book("1", "A", "X", 2000),
                    new Book("2", "B", "Y", 2001));
                await context.SaveChangesAsync();

                var repository = new BookRepository(context);
                var all = (await repository.GetAllAsync()).ToList();
                Assert.Equal(2, all.Count);
            }
        }

        [Fact]
        public async Task SearchAsync_ShouldFindBooksByTitle()
        {
            var options = CreateNewContextOptions();

            using (var context = new LibraryContext(options))
            {
                context.Books.AddRange(
                    new Book("1", "C# Guide", "X", 2000),
                    new Book("2", "Java Guide", "Y", 2001));
                await context.SaveChangesAsync();

                var repository = new BookRepository(context);
                var results = (await repository.SearchAsync("c#")).ToList();
                Assert.Single(results);
                Assert.Equal("C# Guide", results[0].Title);
            }
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveBookFromDatabase()
        {
            var options = CreateNewContextOptions();

            using (var context = new LibraryContext(options))
            {
                var book = new Book("999", "To Delete", "Author", 2024);
                context.Books.Add(book);
                await context.SaveChangesAsync();

                var repository = new BookRepository(context);
                await repository.DeleteAsync(book.Id);

                var all = (await repository.GetAllAsync()).ToList();
                Assert.Empty(all);
            }
        }
    }
}
