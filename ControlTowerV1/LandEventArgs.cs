using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlTowerV1
{
   public  class LandEventArgs : EventArgs
    {

        public string m_flightCode;
        public string m_flightStatus;
        public string m_flightTime;

       // private Flight flt = new Flight();

       /// <summary>
       /// Constructor1 Default
       /// </summary>
       /// <param name="flightCode"></param>
       /// <param name="flightStatus"></param>
       /// <param name="flightTime"></param>
       public LandEventArgs(string flightCode, string flightStatus, string flightTime)
       {


           this.m_flightCode = "" + flightCode;
           this.m_flightStatus = "Flight status :" + "Landed";
           this.m_flightTime = "" + flightTime;

       }

        /// <summary>
       /// Property provides get and set for m_flightCode
        /// </summary>
        public string FlightCode
        {
            get { return this.m_flightCode; }
            set { m_flightCode = value; }

        }

        /// <summary>
        /// Property provides get and set for m_flightStatus
        /// </summary>
        public string FlightStatus
        {
            get { return this.m_flightStatus; }
            set { m_flightStatus = value; }

        }

        /// <summary>
        /// Property provides get and set for m_flightTime
        /// </summary>
        public string FlightTime
        {
            get { return this.m_flightTime; }
            set { m_flightTime = value; }

        }


    }
}
