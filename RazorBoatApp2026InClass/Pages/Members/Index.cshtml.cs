using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System.Collections.Generic;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepository mRepo;
        public string FilterCriteria { get; set; }
        public string FilterBy { get; set; }
        public List<Member> Members { get; set; }

        public IndexModel(IMemberRepository memberRepository)
        {
            mRepo = memberRepository;
        }
        public void OnGet()
        {
            Members = mRepo.GetAllMembers();
        }
    }
}
