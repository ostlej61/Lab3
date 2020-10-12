using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flight holdFlight = new Flight();
        Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When called, displays all created flights
        /// </summary>
        private void DisplayFlights()
        {
            List<Flight> flightList = new List<Flight>();
            List<string> holdList = new List<string>();
            string holdData = "";
            flightList = controller.GetAllFlights();

            foreach (Flight flightObj in flightList)
            {
                holdData = flightObj.FlightId + ", " + flightObj.FlightOrigin + ", " + flightObj.FlightDestination + ", " + flightObj.FlightNumPassengers;
                holdList.Add(holdData);
            }

            lstFlightDisplay.ItemsSource = holdList;
        }

        /// <summary>
        /// On click, will display a list of flights to the user
        /// </summary>
        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            DisplayFlights();
        }

        /// <summary>
        /// on click, will open the Create Flight window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            frmCreateFlight createFlight = new frmCreateFlight();
            createFlight.Show();
        }

        /// <summary>
        /// On click, will open the Update Flight Window with the selected flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (holdFlight.FlightId == null)
            {
                MessageBox.Show("Please display and select the flight you wish to edit.");
            }
            else
            {
                frmUpdateFlight updateFlight = new frmUpdateFlight(holdFlight);
                updateFlight.Show();
                holdFlight = new Flight();
            }
        }

        /// <summary>
        /// on click, will delete the selected flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(holdFlight.FlightId != null)
            {
                controller.DeleteFlight(holdFlight);
                MessageBox.Show("Flight " + holdFlight.FlightId + " successfully Deleted.");
                DisplayFlights();
                holdFlight = new Flight();
            }
            else
            {
                MessageBox.Show("Please display and select the flight you wish to delete.");
            }
        }

        /// <summary>
        /// on click, will select a flight for updating or deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFlightDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstFlightDisplay.SelectedItem == null)
            {
                //do nothing
            }
            else
            {
                string selectedFlight = lstFlightDisplay.SelectedItem.ToString();
                string[] hold = selectedFlight.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                holdFlight.FlightId = hold[0];
                holdFlight.FlightOrigin = hold[1];
                holdFlight.FlightDestination = hold[2];
                holdFlight.FlightNumPassengers = hold[3];
            }

        }

        /// <summary>
        /// on click, will exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
