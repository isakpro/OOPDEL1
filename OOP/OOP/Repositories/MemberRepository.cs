using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OOP.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MemberEntity member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Members.FindAsync(id);
            if (existing != null)
            {
                _context.Members.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MemberEntity>> GetAllAsync()
        {
            return await _context.Members.AsNoTracking().ToListAsync();
        }

        public async Task<MemberEntity?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task UpdateAsync(MemberEntity member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}
