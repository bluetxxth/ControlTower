using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ControlTowerV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControlTowerWindow : Window
    {

        //instance vars
        private int time = 0;
        private string m_flightCode;



        /// <summary>
        /// Constructor1 default
        /// </summary>
        public ControlTowerWindow()
        {
            InitializeComponent();
            UpdateGui();

        }


        /// <summary>
        /// Method initializes GUI
        /// </summary>
        public void UpdateGui()
        {
            //Provide time when aircraft is sent.
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(dispatchTimer_Tick);
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Start();


        }

        /// <summary>
        /// Property provide get and set for m_flightCode
        /// </summary>
        public string FlightCode
        {
            get { return m_flightCode; }
            set { m_flightCode = value; }
        }

        /// <summary>
        /// Method deals with time interval - provides with time when aircraft is sent to runway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dispatchTimer_Tick(object sender, EventArgs e)
        {
            time++;

        }


        /// <summary>
        /// Method handles the Output for the takeoff
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OutputTakeOff(object source, TakeOffEventArgs e)
        {
            
            lvFlights.Items.Add(new { FlightCode = e.FlightCode , Status = e.FlightStatus, Time = e.FlightTime });
           
        }



        /// <summary>
        /// Method handles the output for the change of route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OutputChangeRoute(object source, ChangeRouteEventArgs e)
        {

            lvFlights.Items.Add(new { FlightCode = e.FlightNo  , Status = e.Course, Time = e.FlightTime });
        
          
        }




        /// <summary>
        /// Method handles the output for the landing
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OutputLand(object source, LandEventArgs e)
        {
            
            lvFlights.Items.Add(new { FlightCode= e.FlightCode , Status = e.FlightStatus, Time = e.FlightTime });
           

        }



        /// <summary>
        /// Method to Check for AlphaNumeric.
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns></returns>
        public bool IsAlphaNumeric(string stringToValidate)
        {
            bool isAlpha = false;

            //Alphanumeric regex. To dissallow other than AAA123 format
            Regex objAlphaNumericPattern = new Regex(@"^[A-Z]{3}\d{3}$");

            if (string.IsNullOrEmpty(stringToValidate))
            {
                isAlpha = false;
            }
            if (objAlphaNumericPattern.IsMatch(stringToValidate))
            {
                isAlpha = true;
            }
            else
            {
                isAlpha = false;
            }
            return isAlpha;
        }


        /// <summary>
        /// Method handles input for Flight code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = new Flight();


            FlightCode = txtFlightCode.Text.Trim();


            if (IsAlphaNumeric(FlightCode) == false)
            {
                MessageBox.Show("Invalid Flight Format try AAA123", "Flight Format Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtFlightCode.Clear();
                txtFlightCode.Focus();
                return;

            }
            else
            {
                // MessageBox.Show("Code is:" + FlightCode);

               
                lvFlights.Items.Add((new { FlightCode, Status = "   sent to runway".Trim(), Time = time + " minutes ago" }));
             

                //Assign methods to fire
                flight.Title = "Flight " + txtFlightCode.Text;
                flight.SendTakeOffEvent += OutputTakeOff;
                flight.SendChangeCourseEvent += OutputChangeRoute;
                flight.SendLandEvent += OutputLand;
                flight.FlightCode = txtFlightCode.Text;

    

                //Iberia logo is loaded
                if (FlightCode.StartsWith("IB"))
                {

                    Uri uri = new Uri("/ControlTowerV1;component/Resources/Iberia.JPG", UriKind.RelativeOrAbsolute);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;


                }
                 //KLM logo is loaded
                else if (FlightCode.StartsWith("KL"))
                {

                    Uri uri = new Uri("/ControlTowerV1;component/Resources/Klm.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;
                }

                //Air France logo is loaded
                else if (FlightCode.StartsWith("AF"))
                {
                    
                    Uri uri = new Uri("/ControlTowerV1;component/Resources/AirFrance.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;
                }

                //British airways logo is loaded
                else if (FlightCode.StartsWith("BA"))
                {
                    
                    Uri uri = new Uri("/ControlTowerV1;component/Resources/BritishAirways.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;

                }

                //Luft Hansa logo is loaded
                else if (FlightCode.StartsWith("LH"))
                {
                    
                    Uri uri = new Uri("/ControlTowerV1;component/Resources/Lufthansa.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;

                }

                //Swiss Air Logo is loaded
                else if (FlightCode.StartsWith("SA"))
                {
                    
                    Uri uri = new Uri("/ControlTowerV1;component/Resources/SwissAir.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;

                }

                //If no familiar string found then display unknown airway logo.
                else if ((!FlightCode.StartsWith("SA") || !FlightCode.StartsWith("KL") || !FlightCode.StartsWith("AF") || !FlightCode.StartsWith("BA") || !FlightCode.StartsWith("LH") || !FlightCode.StartsWith("SA")))
                {
                   
                    Uri uri = new Uri("/ControlTowerV1;component/Resources/Unknown.JPG", UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uri);
                    flight.image1.Source = imgSource;

                }

            }

            try
            {
                flight.Show();
            }
            catch { MessageBox.Show("Error showing flight"); }

        }//End method

    }//End class

}//End namespace
