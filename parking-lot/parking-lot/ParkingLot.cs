using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        public Dictionary<object, Car> ticketToCars;
        public int ParkingLotSize { get; } = 2;

        public ParkingLot()
        {
            ticketToCars = new Dictionary<object, Car>();
        }

        public object Park(Car car)
        {
            var ticket = new object();
            var count = ticketToCars.Count;
            if (count < ParkingLotSize)
            {
                ticketToCars.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new Exception("ParkingLot is full");
            }
        }

        public object GetCar(object ticket)
        {
            if (ticketToCars.ContainsKey(ticket))
            {
                var car = ticketToCars[ticket];
                ticketToCars.Remove(ticket);
                return car;


            }
            else
            {
                throw new Exception("Invalid ticket!");

            }

        }
    }
}
