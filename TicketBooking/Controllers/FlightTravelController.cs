using System.Linq;
using System.Net;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.ViewModel;

namespace TicketBooking.Controllers
{
    public class FlightTravelController : Controller
    {
        private BookingContext db = new BookingContext();
        //GET: FlightTravel

        [HttpGet]
        public ActionResult Index()
        {
           var location = db.Locations.ToList();
            var result = (from c in db.FlightTravels.ToList()
                          join fromLocation in location on c.FromLocation equals fromLocation.LocationID
                         join toLocation in location on c.ToLocation equals toLocation.LocationID
                          select new FlightTravelGridViewModel()
                          {
                              Id=c.ID,
                              FromLocation=c.FromLocation,
                              ToLocation=c.ToLocation,
                              FromLocationName=fromLocation.PlaceName,
                              ToLocationName=toLocation.PlaceName
                          }).ToList();

            return View(result);
        }
        //Get To Create
        public ActionResult Create()
        {

            ViewBag.Locations = new SelectList(db.Locations, "LocationID", "PlaceName");
            FlightTravel flightTravel = new FlightTravel();
            return View(flightTravel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FromLocation,ToLocation")] FlightTravel flightTravel)
        {

            ViewBag.Locations = new SelectList(db.Locations, "LocationID", "PlaceName");
            var alreadyExist = db.FlightTravels.Where(x => x.FromLocation == flightTravel.ToLocation).Any();
            if (alreadyExist)
            {
                ModelState.AddModelError("Error", "This Flight travel rate is already setup");
                return View(flightTravel);
            }
            if (ModelState.IsValid)
            {
                db.FlightTravels.Add(flightTravel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightTravel);

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
    }
}
