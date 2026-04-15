using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System.Threading.Tasks;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class LoginModel : PageModel
    {
        private string _listOfMembers = "select * from SailMember";
        [BindProperty] public Member Member { get; set; }
        public string Message;
        private MemberRepository MemberRepository;
        public LoginModel(MemberRepository memberRepository)
        {
            MemberRepository = memberRepository;
        }

        public void OnGet()
        {
        }
        public void OnGetLogout()
        {
            HttpContext.Session.Remove("Email");
        }

        public async Task<IActionResult> OnPost()
        {
            //User loginUser = _userService.VerifyUser(UserName, PassWord);
            Member member = await MemberRepository.VerifyMember(Member.Mail, Member.PhoneNumber);
            if (member != null)
            {

                HttpContext.Session.SetString("Email", member.Mail);
                return RedirectToPage("/Welcome");
            }
            else
            {
                Message = "Invalid username or password";
                Member.Mail = "";
                Member.PhoneNumber = "";
                return Page();
            }

        }
    }
}
