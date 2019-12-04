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
            foreach (var parkingLot in ParkingLot)
            {
                if (parkingLot.IsHasSpace())
                {
                    return parkingLot.Park(car);
                }
            }
            throw new Exception("ParkingLot is full");
        }

        public object GetCar(object ticket)
        {
            foreach (var parkingLot in ParkingLot)
            {
                if (parkingLot.IsHasCar(ticket))
                {
                    return parkingLot.GetCar(ticket);
                }
            }
            throw  new Exception("Invalid ticket!");
        }
    }
}
