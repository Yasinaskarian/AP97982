using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Flight
    {
        //Properties:
        //FlightID: string
        public string ID;
        //Airline: Airline
        public Airline Airline;
        //Capacity: int
        public int Capacity;
        //Source: string
        public string Source;
        //Destination: string
        public string Destenation;
        //FlyDate: DateTime
        public DateTime FlyDate;


        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>
        public Flight(string id, Airline airline, int capacity, string source, string dest,DateTime dateTime)
        {
            //TODO
            ID = id;
            Airline = airline;
            Capacity = capacity;
            Source = source;
            Destenation = dest;
            FlyDate = dateTime;
            DB.AddFlight(this);
        }

    public bool IsFull()
        {
            //TODO
           if (Capacity == 0)
               return true;
         return false;
        }
    }
}
