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
using System.Windows.Shapes;

namespace ControlTowerV1
{
    /// <summary>
    /// Interaction logic for Flight.xaml
    /// </summary>
    public partial class Flight : Window
    {

        //events
        public event EventHandler<TakeOffEventArgs> SendTakeOffEvent;
        public event EventHandler<ChangeRouteEventArgs> SendChangeCourseEvent;
        public event EventHandler<LandEventArgs> SendLandEvent;


        //instance vars
        private string m_route;
        private string m_flightCode ;
        private string m_flightTime;

       
        private ControlTowerWindow ctw = new ControlTowerWindow();


        /// <summary>
        /// Constructor1 Default
        /// </summary>
        public Flight()
        {
            InitializeGUI();
         

        }

     
        /// <summary>
        /// Method initializes GUI
        /// </summary>
        public void InitializeGUI()
        {
            InitializeComponent();
            cmbStatus.IsEnabled = false;
            ComboBoxLoad();
            

        }



        /// <summary>
        /// method Populates comboBox with routes
        /// </summary>
        public void ComboBoxLoad()
        {
            int item = cmbStatus.SelectedIndex;

            // cmbStatus.Items.Add("Select Route");
            cmbStatus.Items.Add("0 degrees");
            cmbStatus.Items.Add("90 degrees");
            cmbStatus.Items.Add("180 degrees");
            cmbStatus.Items.Add("270 degrees");

        }

        /// <summary>
        /// Property provides get and set for m_route
        /// </summary>
        public string NavCourse
        {
            get { return this.m_route; }
            set { m_route = value; }

        }

        /// <summary>
        /// Property provides get and set for m_flightCode
        /// </summary>
        public string FlightCode
        {

            get { return this.m_flightCode;}
            set { m_flightCode = value;}
        }


        /// <summary>
        /// Property provides get and set for m_flightTime
        /// </summary>
        public string Time
        {
            get { return m_flightTime; }
            set { m_flightTime = value; }
        }


        //3.  Raise Event - using the statement RaisEvent+name of the event 
        public void OnSendLand(LandEventArgs e)
        {
            if (SendLandEvent != null)
            {
                SendLandEvent(this, e);
            }
        }

        //3.  Raise Event - using the statement RaisEvent+name of the event 
        public void OnSendTakeOff(TakeOffEventArgs e)
        {
            if (SendTakeOffEvent != null)
            {
                SendTakeOffEvent(this, e);
            }
        }

        //3.  Raise Event - using the statement RaisEvent+name of the event 
        public void OnChangeRoute(ChangeRouteEventArgs e)
        {
            if (SendChangeCourseEvent != null)
            {
                SendChangeCourseEvent(this, e);
            }
        }


        /// <summary>
        /// Method provides event handler for the start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>+-
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            cmbStatus.IsEnabled = true;
            btnLand.IsEnabled = true;
            btnStart.IsEnabled = false;

            TakeOffEventArgs takeOfArgs = new TakeOffEventArgs(FlightCode, NavCourse, DateTime.Now.ToString());
            OnSendTakeOff(takeOfArgs);
            MessageBox.Show("Flight No is:" + FlightCode);



        }

        /// <summary>
        /// Provides event handler for the land button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLand_Click(object sender, RoutedEventArgs e)
        {
            cmbStatus.IsEnabled = false;
            btnLand.IsEnabled = false;
            btnStart.IsEnabled = false;
            ControlTowerWindow twc = new ControlTowerWindow();

            LandEventArgs landEventArgs = new LandEventArgs(FlightCode, NavCourse, DateTime.Now.ToString());
           
            OnSendLand(landEventArgs);

            this.Close();


        }


        /// <summary>
        /// Method provides behavior for route change on comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int item = cmbStatus.SelectedIndex;

            try
            {
                switch (item)
                {
                    case -1: MessageBox.Show("This is the selection is empty");
                        break;

                    case 0:
                        NavCourse = "0 Degrees";
                        FlightCode = this.FlightCode;
                        Time = DateTime.Now.ToString();
                        //Onxxx handler recurring in this switch statement
                        ChangeRouteEventArgs changeRouteEvent = new ChangeRouteEventArgs(FlightCode , NavCourse, DateTime.Now.ToString());
                        OnChangeRoute(changeRouteEvent);
                        break;

                    case 1:
                        NavCourse = "90 Degrees";
                        FlightCode = this.FlightCode;
                        Time = DateTime.Now.ToString();
                    
                        changeRouteEvent = new ChangeRouteEventArgs(FlightCode , NavCourse, DateTime.Now.ToString());
                        OnChangeRoute(changeRouteEvent);
                        break;

                    case 2:
                        NavCourse = "180 Degrees";
                        FlightCode = this.FlightCode;
                        Time = DateTime.Now.ToString();
                      
                        changeRouteEvent = new ChangeRouteEventArgs(FlightCode , NavCourse, DateTime.Now.ToString());
                        OnChangeRoute(changeRouteEvent);
                        break;

                    case 3:
                        NavCourse = "270 Degrees";
                        FlightCode = this.FlightCode;
                        Time = DateTime.Now.ToString();
                     
                       changeRouteEvent = new ChangeRouteEventArgs(FlightCode , NavCourse, DateTime.Now.ToString());
                        OnChangeRoute(changeRouteEvent);
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Error");

            }  

        }//end method

    }
}
