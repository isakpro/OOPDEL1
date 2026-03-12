using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP;
using OOP.Repositories;
using Xunit;

namespace OOP.Tests
{
    public class MemberRepositoryTests
    {
        private static DbContextOptions<LibraryContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddAndGetMember_ShouldWork()
        {
            var options = CreateOptions();
            using var context = new LibraryContext(options);
            var repo = new MemberRepository(context);

            var member = new MemberEntity { MemberId = "M1", Name = "Anna", Email = "a@x", MemberSince = DateTime.Now };
            await repo.AddAsync(member);

            var fetched = (await repo.GetAllAsync()).FirstOrDefault();
            Assert.NotNull(fetched);
            Assert.Equal("Anna", fetched.Name);
        }

        [Fact]
        public async Task DeleteMember_ShouldRemove()
        {
            var options = CreateOptions();
            using var context = new LibraryContext(options);
            var repo = new MemberRepository(context);

            var member = new MemberEntity { MemberId = "M1", Name = "Anna", Email = "a@x", MemberSince = DateTime.Now };
            await repo.AddAsync(member);
            await repo.DeleteAsync(member.Id);

            var all = (await repo.GetAllAsync()).ToList();
            Assert.Empty(all);
        }
    }
}
