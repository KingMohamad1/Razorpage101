using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBookingRepository _repo;
        private IBoatRepository _bRepo;

        [BindProperty]
        public Booking NewBooking { get; set; }
        public Boat newBoat { get; set; }

        public CreateBookingModel(IBookingRepository bookingRepository, IBoatRepository repo)
        {
            _repo = bookingRepository;
            _bRepo = repo;
        }

        public void OnGet()
        {
            NewBooking = new Booking();
            NewBooking.Id = 69;
        }

        public IActionResult OnPost()
        {
            _repo.AddBooking(NewBooking);
            return RedirectToPage("Index");
        }
    }
}
