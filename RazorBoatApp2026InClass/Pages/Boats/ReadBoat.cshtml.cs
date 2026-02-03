using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class ReadBoatModel : PageModel
    {
        private IBoatRepository _repo;

        [BindProperty]
        public Boat OneBoat { get; set; }

        public ReadBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            _repo.SearchBoat(OneBoat.SailNumber);
        }
    }
}
