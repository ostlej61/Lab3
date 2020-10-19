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
        public void CreateFlightTestWithLongId()
        {
            IController controller = new Controller();
            Flight flight = new Flight("testingtime734", "test", "test", "732");
            controller.InsertFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(3, flightList.Count);
        }

        [TestMethod]
        public void CreateFlightTestWithLongOrigin()
        {
            IController controller = new Controller();
            Flight flight = new Flight("tes734", "testingtownusa", "test", "732");
            controller.InsertFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(3, flightList.Count);
        }

        [TestMethod]
        public void CreateFlightTestWithAlphabeticalPassengers()
        {
            IController controller = new Controller();
            Flight flight = new Flight("te34", "test", "test", "whatsgoingonoverhere");
            controller.InsertFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(3, flightList.Count);
        }

        [TestMethod]
        public void CreateFlightTestWithSwappedId()
        {
            IController controller = new Controller();
            Flight flight = new Flight("734tes", "test", "test", "732");
            controller.InsertFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(3, flightList.Count);
        }

        [TestMethod]
        public void UpdateFlightTestWithNumericalDestination()
        {
            IController controller = new Controller();
            Flight flight = new Flight("abc777", "tset", "9921", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[0];

            Assert.AreNotEqual(flight.FlightDestination, holdFlight.FlightDestination);
        }

        [TestMethod]
        public void UpdateFlightTestWithLongDestination()
        {
            IController controller = new Controller();
            Flight flight = new Flight("abc777", "tset", "testakistan", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[0];

            Assert.AreNotEqual(flight.FlightDestination, holdFlight.FlightDestination);
        }

        [TestMethod]
        public void UpdateFlightTestWithShortOrigin()
        {
            IController controller = new Controller();
            Flight flight = new Flight("abc777", "t", "tset", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[0];

            Assert.AreNotEqual(flight.FlightOrigin, holdFlight.FlightOrigin);
        }

        [TestMethod]
        public void UpdateFlightTestWithNumericalOrigin()
        {
            IController controller = new Controller();
            Flight flight = new Flight("abc777", "9927", "tset", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[0];

            Assert.AreNotEqual(flight.FlightOrigin, holdFlight.FlightOrigin);
        }

        [TestMethod]
        public void UpdateFlightTest()
        {
            IController controller = new Controller();
            Flight flight = new Flight("abc777", "tset", "tset", "237");
            controller.UpdateFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Flight holdFlight = new Flight();
            holdFlight = flightList[0];

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

        [TestMethod]
        public void DeleteFlightTestWithNoId()
        {
            IController controller = new Controller();
            Flight flight = new Flight();
            controller.DeleteFlight(flight);

            List<Flight> flightList = new List<Flight>();
            flightList = controller.GetAllFlights();

            Assert.AreEqual(2, flightList.Count);
        }
    }
}
