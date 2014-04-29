using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlTowerV1
{
    public class ChangeRouteEventArgs : EventArgs
    {


        //instance vars
         private string m_strCourse;
         private string m_strTime = DateTime.Now.ToString();
         private string m_strFlightNo;
         public string FlightCode;

         Flight flight = new Flight();


         /// <summary>
         /// Constructor1 Default
         /// </summary>
         /// <param name="FlightCode"></param>
         /// <param name="Status"></param>
         /// <param name="Time"></param>
         public ChangeRouteEventArgs(string FlightCode, string Status, string Time)
         {

             switch (flight.cmbStatus.SelectedIndex)
             {
                 case 0: Status = "Heading" + "0 Degrees";
                     break;
                 case 1: Status = "Heading " + "90 Degrees";
                     break;
                 case 2: Status = "Heading " + "180 Degrees";
                     break;
                 case 3: Status = "Heading" + "270 Degrees";
                     break;

             }

             m_strFlightNo = "" + FlightCode;
             m_strCourse = "Heading " + Status;
             m_strTime = "" + Time;
         }


         /// <summary>
         /// Property provide get and set for m_strCourse
         /// </summary>
         public string Course
         {
             get { return m_strCourse; }
             set { m_strCourse = value; }


         }

         /// <summary>
         /// Property provide get and set for m_strTime
         /// </summary>
         public string FlightTime
         {

             get { return m_strTime; }
             set { m_strTime = value; }

         }

         /// <summary>
         /// Property provide get and set for m_strFlightNo
         /// </summary>
         public string FlightNo
         {
             get { return m_strFlightNo; }
             set { m_strFlightNo = value; }
         }


    }

}
