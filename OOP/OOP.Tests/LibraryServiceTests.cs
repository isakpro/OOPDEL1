using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP;
using Xunit;

namespace OOP.Tests
{
    public class LibraryServiceTests
    {
        private static DbContextOptions<LibraryContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task BorrowAsync_ShouldCreateLoan_AndMarkBookUnavailable()
        {
            var options = CreateOptions();

            using (var context = new LibraryContext(options))
            {
                var book = new Book("1", "Bok", "A", 2020);
                context.Books.Add(book);
                var member = new MemberEntity { MemberId = "M1", Name = "N", Email = "e@x", MemberSince = DateTime.Now };
                context.Members.Add(member);
                await context.SaveChangesAsync();

                var service = new LibraryService(context);
                var loan = await service.BorrowAsync(book.Id, member.Id, 7);

                Assert.NotNull(loan);
                var savedBook = await context.Books.FindAsync(book.Id);
                Assert.False(savedBook.IsAvailable);
            }
        }

        [Fact]
        public async Task ReturnAsync_ShouldSetReturnDate_AndMarkAvailable()
        {
            var options = CreateOptions();

            using (var context = new LibraryContext(options))
            {
                var book = new Book("1", "Bok", "A", 2020);
                context.Books.Add(book);
                var member = new MemberEntity { MemberId = "M1", Name = "N", Email = "e@x", MemberSince = DateTime.Now };
                context.Members.Add(member);
                await context.SaveChangesAsync();

                var loan = new LoanEntity { BookId = book.Id, MemberId = member.Id, LoanDate = DateTime.Now, DueDate = DateTime.Now.AddDays(7) };
                context.Loans.Add(loan);
                book.IsAvailable = false;
                context.Books.Update(book);
                await context.SaveChangesAsync();

                var service = new LibraryService(context);
                await service.ReturnAsync(loan.Id);

                var updatedLoan = await context.Loans.FindAsync(loan.Id);
                var updatedBook = await context.Books.FindAsync(book.Id);
                Assert.NotNull(updatedLoan.ReturnDate);
                Assert.True(updatedBook.IsAvailable);
            }
        }
    }
}
