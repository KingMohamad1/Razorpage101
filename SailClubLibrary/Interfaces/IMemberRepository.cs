using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Interfaces
{
    public interface IMemberRepository
    {
        public Task<int> Count();
        Task AddMember(Member member);
        Task RemoveMember(Member member);
        Task UpdateMember(Member member);
        Task<List<Member>> GetAllMembers();
        Task PrintAll();
        Task<Member?> SearchMember(int id);
        Task<List<Member>> FilterMembers(string filterCriteria);
    }
}
