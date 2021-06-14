using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;
        public BookingRepository(BookingContext context)
        {
            _context = context;
        }
        public int AddBooking(Booking bookingEntity)
        {
            int result = -1;
            if(bookingEntity != null)
            {
                _context.Bookings.Add(bookingEntity);
                _context.SaveChanges();
                result = bookingEntity.BookingID;
            }
            return result;
        }

        public void DeleteBooking(int BookingID)
        {
            Booking bookingEntity = _context.Bookings.Find(BookingID);
            _context.Bookings.Remove(bookingEntity);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetAllBooking()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetAllBookingById(int BookingID)
        {
            return _context.Bookings.Find(BookingID);
        }

        public int UpdateBooking(Booking bookingEntity)
        {
            int result = -1;
            if(bookingEntity != null)
            {
                _context.Entry(bookingEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = bookingEntity.BookingID;
            }
            return result;
        }
    }
}