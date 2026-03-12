using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberEntity>> GetAllAsync();
        Task<MemberEntity?> GetByIdAsync(int id);
        Task AddAsync(MemberEntity member);
        Task UpdateAsync(MemberEntity member);
        Task DeleteAsync(int id);
    }
}
