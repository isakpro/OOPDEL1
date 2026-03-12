using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP;
using OOP.Repositories;
using Xunit;

namespace OOP.Tests
{
    public class LoanRepositoryTests
    {
        private static DbContextOptions<LibraryContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddAndGetActiveLoans_ShouldReturnActive()
        {
            var options = CreateOptions();
            using var context = new LibraryContext(options);
            var repo = new LoanRepository(context);

            var book = new Book("1", "Bok", "A", 2020);
            context.Books.Add(book);
            var member = new MemberEntity { MemberId = "M1", Name = "N", Email = "e@x", MemberSince = DateTime.Now };
            context.Members.Add(member);
            await context.SaveChangesAsync();

            var loan = new LoanEntity { BookId = book.Id, MemberId = member.Id, LoanDate = DateTime.Now, DueDate = DateTime.Now.AddDays(7) };
            await repo.AddAsync(loan);

            var active = (await repo.GetActiveLoansAsync()).ToList();
            Assert.Single(active);
            Assert.Equal(book.Id, active[0].BookId);
        }
    }
}
