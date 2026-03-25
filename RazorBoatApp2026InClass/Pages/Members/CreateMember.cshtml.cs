using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Threading.Tasks;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private IMemberRepository _repo;

        [BindProperty]
        public Member NewMember { get; set; }

        public CreateMemberModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _repo.AddMember(NewMember);
            return RedirectToPage("Index");
        }
    }
}
