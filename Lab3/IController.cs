using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IController
    {
        List<Flight> GetAllFlights();

        void InsertFlight(Flight flight);

        void UpdateFlight(Flight flight);

        void DeleteFlight(Flight flight);
    }
}
