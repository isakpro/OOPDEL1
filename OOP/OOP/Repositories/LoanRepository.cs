using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OOP.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LoanEntity loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LoanEntity>> GetActiveLoansAsync()
        {
            return await _context.Loans
                .Where(l => l.ReturnDate == null)
                .Include(l => l.Book)
                .Include(l => l.Member)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(LoanEntity loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
