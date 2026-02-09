using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBookingRepository _repo;

        [BindProperty]
        public Booking NewBooking { get; set; }

        public CreateBookingModel(IBookingRepository bookingRepository)
        {
            _repo = bookingRepository;
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
