using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingSmartBoy: ParkingBoy
    {
        public ParkingSmartBoy(List<ParkingLot> parkingLot) : base(parkingLot)
        {
        }


        public override object Park(Car car)
        {
            ParkingLot maxParkingLot = ParkingLot[0];
            foreach (var parkingLot in ParkingLot)
            {
                if (parkingLot.GetSpace() > maxParkingLot.GetSpace())
                {
                    maxParkingLot = parkingLot;
                }
            }

            if (maxParkingLot.GetSpace() == 0)
            {
                throw new Exception("parking lot has full!");
            }

            return maxParkingLot.Park(car);
        }
    }
}
