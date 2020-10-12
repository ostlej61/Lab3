using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3
{
    public class Database
    {
        private string connectionStringToDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;

        /// <summary>
        /// When called, will get a list of all flights from the database
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetAllFlights()
        {
            List<Flight> flightList = new List<Flight>();
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * from tblFlight", conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            int count = reader.FieldCount;
            StringBuilder str = new StringBuilder();
            while (reader.Read())
            {
                Flight flight = new Flight();

                for (int i = 0; i < count; i++)
                {
                    if(i == 0)
                    {
                        flight.FlightId = (string)reader.GetValue(i);
                    }
                    if (i == 1)
                    {
                        flight.FlightOrigin = (string)reader.GetValue(i);
                    }
                    if (i == 2)
                    {
                        flight.FlightDestination = (string)reader.GetValue(i);
                    }
                    if (i == 3)
                    {
                        flight.FlightNumPassengers = (string)reader.GetValue(i);
                    }
                }

                flightList.Add(flight);

            }
            conn.Close();
            return flightList;
        }

        /// <summary>
        /// when called, will insert a passed flight to the database
        /// </summary>
        /// <param name="flight"></param>
        public void InsertFlight(Flight flight)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionStringToDB);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblFlight VALUES(@id, @origin, @destination, @passengers)", conn);
                cmd.Parameters.AddWithValue("@id", flight.FlightId);
                cmd.Parameters.AddWithValue("@origin", flight.FlightOrigin);
                cmd.Parameters.AddWithValue("@destination", flight.FlightDestination);
                cmd.Parameters.AddWithValue("@passengers", flight.FlightNumPassengers);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// when called, will update a passed flight on the database
        /// </summary>
        /// <param name="flight"></param>
        public void UpdateFlight(Flight flight)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionStringToDB);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE tblFlight SET Origin = @origin, Destination = @destination, Passengers = @passengers WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", flight.FlightId);
                cmd.Parameters.AddWithValue("@origin", flight.FlightOrigin);
                cmd.Parameters.AddWithValue("@destination", flight.FlightDestination);
                cmd.Parameters.AddWithValue("@passengers", flight.FlightNumPassengers);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// when called, will delete a flight from the database
        /// </summary>
        /// <param name="flight"></param>
        public void DeleteFlight(Flight flight)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionStringToDB);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM tblFlight WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", flight.FlightId);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
