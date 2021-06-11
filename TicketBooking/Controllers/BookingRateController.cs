using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.Services;
using TicketBooking.ViewModel;

namespace TicketBooking.Controllers
{
    public class BookingRateController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: BookingRate
        public ActionResult Index()
        {
            var location = db.Locations.ToList();
            var result = (from bookingRates in db.BookingRates.ToList()
                          join flightTravels in db.FlightTravels on bookingRates.FlightTravelID equals flightTravels.ID
                          join fromLocation in location on flightTravels.FromLocation equals fromLocation.LocationID
                          join toLocation in location on flightTravels.ToLocation equals toLocation.LocationID
                          select new BookingRateViewModel()
                          {
                              Id = bookingRates.BookingRateID,
                              Rate = bookingRates.Rate,
                              FromLocation = flightTravels.FromLocation,
                              ToLocation = flightTravels.ToLocation,
                              FromLocationName = fromLocation.PlaceName,
                              ToLocationName = toLocation.PlaceName
                          }).ToList();
            return View(result);
        }
        //Get of Create
        public ActionResult Create()
        {
            setViwBagForDestination();
            BookingRate bookingRate = new BookingRate();
            return View(bookingRate);
        }
        private void setViwBagForDestination()
        {
            BookingServices _bookingServices = new BookingServices();
            var destinations = _bookingServices.GetDestinations().ToList();
            ViewBag.FlighTravels = new SelectList(destinations, "Id", "Name");
        }
        [HttpPost]

        public ActionResult Create([Bind(Include = "BookingRateID,Rate,FlightTravelID")] BookingRate bookingRate)
        {
            setViwBagForDestination();
            var alreadyExist = db.BookingRates.Where(x => x.FlightTravelID == bookingRate.FlightTravelID).Any();
            if (alreadyExist)
            { 
                ModelState.AddModelError("Error", "This Flight travel rate is already setup");
                return View(bookingRate);
            }
            if (ModelState.IsValid)
            {
                db.BookingRates.Add(bookingRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingRate);
        }
        //Get for Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRate bookingRates = db.BookingRates.Find(id);
            if (bookingRates == null)
            {
                return HttpNotFound();
            }
            return View(bookingRates);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BookingRate booking = db.BookingRates.Find(id);
            db.BookingRates.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Get Method of Edit
        public ActionResult Edit(int? id)
        {
            setViwBagForDestination();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRate booking = db.BookingRates.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "BookingRateID,Rate,FlightTravelID")] BookingRate bookingRate)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(bookingRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingRate);
        }
    }
}