using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP.Repositories
{
    public interface ILoanRepository
    {
        Task<IEnumerable<LoanEntity>> GetActiveLoansAsync();
        Task AddAsync(LoanEntity loan);
        Task UpdateAsync(LoanEntity loan);
    }
}
