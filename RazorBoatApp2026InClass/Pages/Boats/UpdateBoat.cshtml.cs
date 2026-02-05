using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBoatApp2026InClass.Pages.Shared;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class UpdateBoatModel : PageModel
    {
        private IBoatRepository _repo;
        [BindProperty]
        public Boat BoatToUpdate { get; set; }
        public UpdateBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet(string sailNumber)
        {
            BoatToUpdate = _repo.SearchBoat(sailNumber);
        }
        public IActionResult OnPostUpdate()
        {
            _repo.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }
        public IActionResult OnPostDelete()
        {
            _repo.RemoveBoat(BoatToUpdate.SailNumber);
            return RedirectToPage("Index");
        }
    }
}
