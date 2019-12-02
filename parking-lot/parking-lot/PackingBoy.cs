using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class PackingBoy
    {
        public List<ParkingLot> ParkingLot { get; }

        public PackingBoy(List<ParkingLot> parkingLot)
        {
            ParkingLot = parkingLot;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            for (int i = 0; i < ParkingLot.Count; i++)
            {
                if (ParkingLot[i].ticketToCars.Count == ParkingLot[i].ParkingLotSize)
                {
                    ticket = ParkingLot[i + 1].Park(car);
                    break;
                }
                else
                {
                    ticket = ParkingLot[i].Park(car);
                    break;
                }
            }

            return ticket;
        }

        public object GetCar(object ticket)
        {
            int index = 0;
            bool flag = false;
            for (int i = 0; i < ParkingLot.Count; i++)
            {
                if (ParkingLot[i].ticketToCars.ContainsKey(ticket))
                {
                    index = i;
                    flag = true;
                }
            }

            if (flag)
            {
                var car = ParkingLot[index].ticketToCars[ticket];
                ParkingLot[index].ticketToCars.Remove(ticket);
                return car;
            }
            else
            {
                throw new Exception("Invalid ticket!");
            }
        }
    }
}
