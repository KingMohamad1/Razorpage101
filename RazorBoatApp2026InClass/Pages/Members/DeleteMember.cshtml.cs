using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
        private IMemberRepository _repo;

        [BindProperty]
        public Member ChosenMember { get; set; }

        public DeleteMemberModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }

        public IActionResult OnGet(string phoneNumber)
        {
            ChosenMember = _repo.SearchMember(phoneNumber);
            return Page();
        }

        public IActionResult OnPostDelete(Member member)
        {
            _repo.RemoveMember(member);
            return RedirectToPage("Index");
        }
        public IActionResult OnPost(string phoneNumber)
        {
            return RedirectToPage("Index");
        }
    }
}
