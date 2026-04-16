using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Threading.Tasks;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class LoginPageModel : PageModel
    {
        private IMemberRepository MemberRepository;
        public string? Email { get; set; }

        public Member? CurrentMember { get; set; }

        public LoginPageModel(IMemberRepository memberRepository)
        {
            MemberRepository = memberRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            Email = HttpContext.Session.GetString("Email")!;
            if (Email == null)
            {
                return RedirectToPage("Members/Login");
            }
            else
            {
                CurrentMember = await MemberRepository.SearchMemberByMail(Email);
                    //_userService.GetUserByUserName(UserName);
            }
            return Page();
        }
    }
}
