using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class LocationController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: Location
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }
        //GEt Create
        public ActionResult Create()
        {
            Location location = new Location();
            return View(location);
     
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "LocationID,PlaceName")] Location location)
        
        {
            var alreadyExist = db.Locations.Where(x=>x.PlaceName.ToLower().Trim() == location.PlaceName.ToLower().Trim()).Any();
            if (alreadyExist)
            {
                ModelState.AddModelError("Error", "This place is already exist int location table");
                location.PlaceName = null;
                return View(location);
            }
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(location);
        }
        //Details Get Mehtod
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        //Get Method of Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "LocationID,PlaceName")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }
        //Get For Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}