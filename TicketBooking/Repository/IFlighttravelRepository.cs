using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Models;
using TicketBooking.ViewModel;

namespace TicketBooking.Repository
{
  public interface IFlighttravelRepository
    {
        IEnumerable<FlightTravelGridViewModel> GetAllFlightTravel();
        FlightTravel GetFlightTravelById(int ID);
        int AddFlightTravel(FlightTravel flightTravelEntity);
        int UpdateFlightTravel(FlightTravel flightTravelEntity);
        void DeleteFlightTravel(int ID);
    }
}
