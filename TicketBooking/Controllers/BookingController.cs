using System.Linq;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Services;
using TicketBooking.ViewModel;

namespace TicketBooking.Controllers
{
    public class BookingController : Controller
    {
        BookingServices _bookingServices = null;
        private BookingContext db = new BookingContext();
        public BookingController()
        {
            _bookingServices = new BookingServices();

        }
        [HttpGet]
        public JsonResult GetRate(int flightTravelId)
        {
            var rateInfo = db.BookingRates.Where(x => x.FlightTravelID == flightTravelId).FirstOrDefault();
            if (rateInfo != null)
            {
                return Json(rateInfo.Rate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0.00, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Booking
        public ActionResult Index()
        {
            // var bookings = db.Bookings.Include(x => x);
            var bookings = _bookingServices.GetBookings().ToList();
            return View(bookings);
        }
        //Get
        public ActionResult Create()
        {
            setViewBAgForRate();
            setViwBagForDestination();
            BookingViewModel booking = new BookingViewModel();
            return View(booking);
        }
        [HttpPost]
        public ActionResult Create(/*[Bind(Include = BookingViewModel.BindProperty)]*/ BookingViewModel vm)
        {
            setViewBAgForRate();
            setViwBagForDestination();            
            if (ModelState.IsValid)
            {
                _bookingServices.AddBooking(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        private void setViwBagForDestination()
        {
            var destinations = _bookingServices.GetDestinations().ToList();
            ViewBag.Destination = new SelectList(destinations, "Id", "Name");
        }
        private void setViewBAgForRate()
        {
            var rates = _bookingServices.GetRates().ToList();
            ViewBag.Rate = new SelectList(rates, "BookingRateID", "Rate");
        }
    }
}
