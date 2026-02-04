using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _repo;

        [BindProperty]
        public Boat ChosenBoat { get; set; }

        public DeleteBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _repo.RemoveBoat(ChosenBoat.SailNumber);
            return RedirectToPage("Index");
        }
    }
}
