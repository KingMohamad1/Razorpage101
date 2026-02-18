using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        public List<Boat> Boats { get; set; }
        private IBoatRepository _repo;
        [BindProperty]
        public Boat newBoat { get; set; }
        public string FilterCriteria { get; set; }
        public ChooseBoatModel(IBoatRepository repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = _repo.FilterBoats(FilterCriteria);
            }
            else
                Boats = _repo.GetAllBoats();
        }
        public void OnPost()
        {

        }
    }
}
