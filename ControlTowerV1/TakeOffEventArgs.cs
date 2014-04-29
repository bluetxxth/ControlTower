using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlTowerV1
{
    public class TakeOffEventArgs : EventArgs
    {
        public string m_flightCode;
        public string m_flightStatus;
        public string m_flightTime;

        //Flight flight = new Flight();


        /// <summary>
        /// Constructor1 default
        /// </summary>
        /// <param name="flightCode"></param>
        /// <param name="flightStatus"></param>
        /// <param name="flightTime"></param>
        public TakeOffEventArgs(string flightCode, string flightStatus, string flightTime)
        {

            m_flightCode = ""+ flightCode;
            m_flightStatus = "Flight status :" + "Take OFF";
            m_flightTime = "" + flightTime;



        }


        /// <summary>
        /// 
        /// </summary>
        public string FlightCode 
        {
            get {return this.m_flightCode ;}
            set { m_flightCode = value;}

        }

        /// <summary>
        /// 
        /// </summary>
        public string FlightStatus
        {
            get { return this.m_flightStatus; }
            set { m_flightStatus = value; }

        }

        /// <summary>
        /// 
        /// </summary>
        public string FlightTime
        {
            get { return this.m_flightTime; }
            set { m_flightTime = value; }

        }

    }
}
