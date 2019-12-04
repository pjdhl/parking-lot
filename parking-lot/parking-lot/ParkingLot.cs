using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        public Dictionary<object, Car> ticketToCars;

        private int ParkingLotSize { get; }

        public ParkingLot(int parkingLotSize)
        {
            ticketToCars = new Dictionary<object, Car>();
            ParkingLotSize = parkingLotSize;
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

        public bool IsHasSpace()
        {
            if (ticketToCars.Count == ParkingLotSize)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsHasCar(object ticket)
        {
            return ticketToCars.ContainsKey(ticket);
        }

        public int GetLot()
        {
            return ParkingLotSize - ticketToCars.Count;
        }

    }
}
