using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System.Collections.Generic;
using System.Configuration;

namespace Lab4UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllFlightsTest()
        {
            IController controller = new Controller();
            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(2, flightList.Count);
        }

        [TestMethod]
        public void CreateFlightTest()
        {
            IController controller = new Controller();
            Flight flight = new Flight("tes734", "test", "test", "732");
            controller.InsertFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(3, flightList.Count);
        }

        [TestMethod]
        public void UpdateFlightTest()
        {
            IController controller = new Controller();
            Flight flight = new Flight("tes734", "tset", "tset", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[2];

            Assert.AreEqual(flight.FlightId, holdFlight.FlightId);
        }

        [TestMethod]
        public void DeleteFlightTest()
        {
            IController controller = new Controller();
            Flight flight = new Flight("tes734", "tset", "tset", "237");
            controller.DeleteFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(2, flightList.Count);
        }
    }
}
