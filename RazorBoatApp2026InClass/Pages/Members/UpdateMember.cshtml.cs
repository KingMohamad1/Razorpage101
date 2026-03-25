using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class UpdateMemberModel : PageModel
    {
        private IMemberRepository _repo;
        [BindProperty]
        public Member MemberToUpdate { get; set; }
        public UpdateMemberModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }
        public async Task OnGetAsync(int id)
        {
            MemberToUpdate = await _repo.SearchMember(id);
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            await _repo.UpdateMember(MemberToUpdate);
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDelete()
        {
            await _repo.RemoveMember(MemberToUpdate);
            return RedirectToPage("Index");
        }
    }
}
