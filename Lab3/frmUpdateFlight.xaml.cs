using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for frmUpdateFlight.xaml
    /// </summary>
    public partial class frmUpdateFlight : Window
    {
        Flight flight = new Flight();
        Controller controller = new Controller();

        public frmUpdateFlight(Flight updatingFlight)
        {
            InitializeComponent();
            flight = updatingFlight;
        }

        /// <summary>
        /// on load, will clear out the error message and the textboxes, then focus on the first text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //clear error message
            lblError.Content = string.Empty;

            //set content
            lblId.Content = flight.FlightId;
            txtOrigin.Text = flight.FlightOrigin;
            txtDestination.Text = flight.FlightDestination;
            txtPassengers.Text = flight.FlightNumPassengers;

            //focus on first textbox
            txtOrigin.Focus();
            txtOrigin.SelectAll();
        }
        private void txtOrigin_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        private void txtDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        private void txtPassengers_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        /// <summary>
        /// on click, clears out all textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOrigin.Text = string.Empty;
            txtDestination.Text = string.Empty;
            txtPassengers.Text = string.Empty;
        }

        /// <summary>
        /// on click, will close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// on click, will submit all data entered to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string id = lblId.Content.ToString();
            string origin = txtOrigin.Text.ToLower();
            string destination = txtDestination.Text.ToLower();
            string passengers = txtPassengers.Text;

            if (!origin.All(char.IsLetter))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Origin can only contains letters. Please try again.";
                txtOrigin.Focus();
                txtOrigin.SelectAll();
            }
            else if (!destination.All(char.IsLetter))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Destination can only contains letters. Please try again.";
                txtDestination.Focus();
                txtDestination.SelectAll();
            }
            else if (!passengers.All(char.IsDigit))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Passengers can only contains numbers. Please try again.";
                txtPassengers.Focus();
                txtPassengers.SelectAll();
            }
            else //everything is correct
            {
                flight = new Flight(id, origin, destination, passengers);
                controller.UpdateFlight(flight);
                MessageBox.Show("Flight " + flight.FlightId + " successfully updated.");
            }

        }
    }
}
