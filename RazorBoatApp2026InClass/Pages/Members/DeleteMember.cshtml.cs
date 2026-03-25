using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnGet(int id)
        {
            ChosenMember = await _repo.SearchMember(id);
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            //await _repo.RemoveMember(member);
            await _repo.RemoveMember(ChosenMember);
            return RedirectToPage("Index");
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
