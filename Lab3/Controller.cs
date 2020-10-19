using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Controller : IController
    {
        /// <summary>
        /// When called, will get a list of flights from the database
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetAllFlights()
        {
            IDatabase database = new Database();
            List<Flight> flightList = new List<Flight>();
            flightList = database.GetAllFlights();
            return flightList;
        }

        /// <summary>
        /// when called, will pass a flight to be inserted from the UI to the Database
        /// </summary>
        /// <param name="flight"></param>
        public void InsertFlight(Flight flight)
        {
            IDatabase database = new Database();
            database.InsertFlight(flight);
        }

        /// <summary>
        /// when called, will pass a flight to be updated from the UI to the Database
        /// </summary>
        /// <param name="flight"></param>
        public void UpdateFlight(Flight flight)
        {
            IDatabase database = new Database();
            database.UpdateFlight(flight);
        }

        /// <summary>
        /// when called, will pass a flight to be deleted from the UI to the Database
        /// </summary>
        /// <param name="flight"></param>
        public void DeleteFlight(Flight flight)
        {
            IDatabase database = new Database();
            database.DeleteFlight(flight);
        }
    }
}
