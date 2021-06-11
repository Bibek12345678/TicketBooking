using System.Linq;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.ViewModel;

namespace TicketBooking.Services
{
    public class BookingServices
    {
        private BookingContext db = null;
        public BookingServices()
        {
            db = new BookingContext();
        }

        public IQueryable<Booking> Bookings()
        {
            return db.Bookings;
        }
        public IQueryable<BookingViewModel> GetBookings()
        {
            var bookingData = Bookings();
            var result = (from c in bookingData
                           join d in db.FlightTravels on c.FlightTravelID equals d.ID
                          join e in db.Locations on d.FromLocation equals e.LocationID
                          join f in db.Locations on d.ToLocation equals f.LocationID
                          select new BookingViewModel()
                          {
                              Id = c.BookingID,
                              Name = c.Name,
                              Gmail = c.Gmail,
                              PhoneNo = c.PhoneNo,
                              Rate = c.Rate,
                              NoOfPeople = c.NoOfPerson,                          
                              FlightTravelID = c.FlightTravelID,
                              DestinationName = e.PlaceName + " - " + f.PlaceName,
                              Total=c.Total
                           
                          }).AsQueryable();
            return result;
        }

        internal void AddBooking(BookingViewModel vm)
        {

            var booking = new Booking()
            {
                FlightTravelID = vm.FlightTravelID,
                Gmail = vm.Gmail,
                Name = vm.Name,
                PhoneNo = vm.PhoneNo,
                Rate = vm.Rate,
                NoOfPerson = vm.NoOfPeople,
                Total =(int) (vm.NoOfPeople * vm.Rate)              
            };

            db.Bookings.Add(booking);
            db.SaveChanges();
        }
        internal IQueryable<DropDownViewModel> GetDestinations()
        {
            var destinations = (from c in db.FlightTravels
                                join d in db.Locations on c.FromLocation equals d.LocationID
                                join e in db.Locations on c.ToLocation equals e.LocationID
                                select new DropDownViewModel()
                                {
                                    Id = c.ID,
                                    Name = d.PlaceName + "-" + e.PlaceName
                                });
            return destinations;
        }
        internal IQueryable<BookingViewModel> GetRates()
        {
            var rates = (from d in db.BookingRates
                         select new BookingViewModel()
                         {
                             BookingRateID = d.BookingRateID,
                             Rate = d.Rate
                         });
            return rates;
        }

    }
}
