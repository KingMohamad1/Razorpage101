
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository bRepo;
        public List<Boat> Boats { get; set; }
        public Boat b;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }
        public string FilterCriteria { get; set; }

        public IndexModel(IBoatRepository boatRepository)
        {
            bRepo = boatRepository;
        }
        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = bRepo.FilterBoats(FilterCriteria);
            }
            else
                Boats = bRepo.GetAllBoats();
            switch (SortBy)
            {
                case "ID":
                    Boats.Sort((a, b) => a.CompareToID(b));
                    return Page();
                case "SailNumber":
                    Boats.Sort((a, b) => a.CompareToSailNumber(b));
                    return Page();
                case "YearOfConstruction":
                    Boats.Sort((a, b) => a.CompareToByYear(b));
                    return Page();
            }
            //if (SortBy == "ID")
            //{

            //}else if (SortBy == "SailNumber")
            //{
            //    Boats.Sort();
            //    return Page();
            //}else if (SortBy == "YearOfConstruction")
            //{
            //    Boats.Sort();
            //    return Page();
            //}
            return Page();
        }
    }
}
