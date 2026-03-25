using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Filter;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepository mRepo;
        public List<Member> Members { get; set; }
        [BindProperty]
        public Member Member { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        [BindProperty(SupportsGet = true)]
        public MemberType? SelectedMemberType { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterBy { get; set; }

        public IndexModel(IMemberRepository memberRepository)
        {
            mRepo = memberRepository;
        }
        public async Task OnGet()
        {
            try
            {
                //Members = mRepo.GetAllMembers();
                Members = MemberFilter(await mRepo.GetAllMembers());
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        public async Task<IActionResult> OnPost()
        {
            await mRepo.RemoveMember(Member);
            return RedirectToPage("index");
        }
        private List<Member> MemberFilter(List<Member> members)
        {
            List<Predicate<Member>> predicates = new List<Predicate<Member>>();
            if (SelectedMemberType.HasValue)
            {
                predicates.Add(b => b.TheMemberType == SelectedMemberType.Value);
            }
            if (!string.IsNullOrWhiteSpace(FilterCriteria))
            {
                switch (FilterBy)
                {
                    case "All":
                        predicates.Add(b => b.FilterAll().Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "FirstName":
                        predicates.Add(b => !string.IsNullOrEmpty(b.FirstName) && b.FirstName.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "SurName":
                        predicates.Add(b => !string.IsNullOrEmpty(b.SurName) && b.SurName.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "PhoneNumber":
                        predicates.Add(b => !string.IsNullOrEmpty(b.PhoneNumber) && b.PhoneNumber.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Mail":
                        predicates.Add(b => !string.IsNullOrEmpty(b.Mail) && b.Mail.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "City":
                        predicates.Add(b => !string.IsNullOrEmpty(b.City) && b.City.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    default:
                        break;
                }
            }
            return members;
            //return FilterFunctions<Member>.Filter(members, predicates);
        }
    }
}