using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class PackingBoy
    {
        public List<ParkingLot> PackingLot { get; }

        public PackingBoy(List<ParkingLot> packingLot)
        {
            PackingLot = packingLot;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            for (int i = 0; i < PackingLot.Count; i++)
            {
                if (PackingLot[i].ticketToCars.Count == PackingLot[i].ParkingLotSize)
                {
                    ticket = PackingLot[i + 1].Park(car);
                    break;
                }
                else
                {
                    ticket = PackingLot[i].Park(car);
                    break;
                }
            }

            return ticket;
        }

    }
}
