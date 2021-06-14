using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.Repository;

namespace TicketBooking.Controllers
{
    public class LocationController : Controller
    {
        //private BookingContext db = new BookingContext();
        private ILocationRepository _locationRepository;
        public LocationController()
        {
            _locationRepository = new LocationRepository(new DAL.BookingContext());
        }
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
       
        public ActionResult Index()
        {
            var model = _locationRepository.GetAllLocation();
            return View(model);
        }
        //GEt Create
        public ActionResult Create()
        {
            Location location = new Location();
           if(TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Location Failed";
            }
            return View(location);
     
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "LocationID,PlaceName")] Location location)
        
        {
          //  var alreadyExist = _locationRepository.Locations.Where(x=>x.PlaceName.ToLower().Trim() == location.PlaceName.ToLower().Trim()).Any();
            //if (alreadyExist)
            //{
            //    ModelState.AddModelError("Error", "This place is already exist int location table");
            //    location.PlaceName = null;
            //    return View(location);
            //}
            if (ModelState.IsValid)
            {
                int result = _locationRepository.AddLocation(location);
                if(result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("Create");
                }
                
            }
            return View();
        }
        ////Details Get Mehtod
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = db.Locations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}
        //Get Method of Edit
        [HttpGet]
        public ActionResult Edit(int? LocationID)
        {
          if(TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Location Failed";
            }
            Location location = _locationRepository.GetLocationById(LocationID);
            return View(location);
        }
        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                int result = _locationRepository.UpdateLocation(location);
                if(result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        //Get For Delete
        [HttpGet]
        public ActionResult Delete(int? LocationID)
        {
            Location location = _locationRepository.GetLocationById(LocationID);
            return View(location);
        }
        [HttpPost]
        public ActionResult Delete(Location location)
        {
           if(TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Location Failed";
            }
            _locationRepository.DeleteLocation(location.LocationID);
            return RedirectToAction("Index");
        }
    }
}