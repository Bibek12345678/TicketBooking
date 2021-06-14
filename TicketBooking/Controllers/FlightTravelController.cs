using System.Linq;
using System.Net;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.Repository;
using TicketBooking.ViewModel;

namespace TicketBooking.Controllers
{
    public class FlightTravelController : Controller
    {
        private BookingContext db = new BookingContext();
        //GET: FlightTravel
        private IFlighttravelRepository _flightTravelRepository;
        public FlightTravelController()
        {
            _flightTravelRepository = new FlightTravelRepository(new DAL.BookingContext());
        }
        public FlightTravelController(IFlighttravelRepository flighttravelRepository)
        {
            _flightTravelRepository = flighttravelRepository;
        }
        //[HttpGet]
        //public ActionResult Index()
        //{

        //   var location = db.Locations.ToList();
        //    var result = (from c in db.FlightTravels.ToList()
        //                  join fromLocation in location on c.FromLocation equals fromLocation.LocationID
        //                 join toLocation in location on c.ToLocation equals toLocation.LocationID
        //                  select new FlightTravelGridViewModel()
        //                  {
        //                      Id=c.ID,
        //                      FromLocation=c.FromLocation,
        //                      ToLocation=c.ToLocation,
        //                      FromLocationName=fromLocation.PlaceName,
        //                      ToLocationName=toLocation.PlaceName
        //                  }).ToList();

        //    return View(result);
        //}
        public ActionResult Index()
        {
            // var bookings = db.Bookings.Include(x => x);
            var flightTravel = _flightTravelRepository.GetAllFlightTravel().ToList();
            return View(flightTravel);
        }
        //Get To Create
        public ActionResult Create()
        {
            SetViewBagforFlightTravel();
            FlightTravel flightTravel = new FlightTravel();
            return View(flightTravel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FromLocation,ToLocation")] FlightTravel flightTravel)
        {
            
            //ViewBag.Locations = new SelectList(db.Locations, "LocationID", "PlaceName");
            //var alreadyExist = db.FlightTravels.Where(x => x.FromLocation == flightTravel.ToLocation).Any();
            //if (alreadyExist)
            //{
            //    ModelState.AddModelError("Error", "This Flight travel rate is already setup");
            //    return View(flightTravel);
            //}
            if (ModelState.IsValid)
            {
                int result = _flightTravelRepository.AddFlightTravel(flightTravel);
                if(result > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("Create");
                }

            }
            return View();

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightTravel flight = db.FlightTravels.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        public ActionResult Delete(int id)
        {
            FlightTravel flightTravel = db.FlightTravels.Find(id);
            db.FlightTravels.Remove(flightTravel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void SetViewBagforFlightTravel()
        {
            var flightTravel = _flightTravelRepository.GetAllFlightTravel().ToList();
            ViewBag.Locations = new SelectList(db.Locations, "LocationID", "PlaceName");
        }
      
    }
}
