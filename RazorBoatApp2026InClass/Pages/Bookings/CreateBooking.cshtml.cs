using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        public Booking Booking { get; set; }
        private IBookingRepository _repo;
        private IBoatRepository _bRepo;
        private IMemberRepository _mRepo;
        //Lave felter til startdate/enddate
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Destination { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        public Boat newBoat { get; set; }
        public Member Member { get; set; }

        public CreateBookingModel(IBookingRepository bookingRepository, IBoatRepository repo, IMemberRepository memberRepo)
        {

            //INjecte memberrepository
            _mRepo = memberRepo;
            _repo = bookingRepository;
            _bRepo = repo;
        }

        public void OnGet(string sailNumber)
        {
            newBoat =_bRepo.SearchBoat(sailNumber)!;
        }

        public IActionResult OnPost(string sailNumber, string phoneNumber)
        {
            //finde medlemmet udfra telefon nr
            phoneNumber = PhoneNumber;
            //PhoneNumber = Member.PhoneNumber;
            //Member.PhoneNumber = PhoneNumber;
            //finde boat ud fra sailnumber
            newBoat = _bRepo.SearchBoat(sailNumber)!;
            //LAve et booking
            Booking = new Booking(newBoat.Id, StartDate, EndDate, Destination, Member, newBoat);
            //Adde booking til bookingrepo
            _repo.AddBooking(Booking);
            //_repo.AddBooking(NewBooking);
            return RedirectToPage("Index");
        }
    }
}
