using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingSmartBoy: PackingBoy
    {
        public ParkingSmartBoy(List<ParkingLot> parkingLot) : base(parkingLot)
        {
        }

        public ParkingLot GetMaximumParkingLot()
        {
            int maximum = 0;
            ParkingLot maxParkingLot = ParkingLot[0];
            foreach (var parkingLot in ParkingLot)
            {
                if (parkingLot.GetSpace() > maximum)
                {
                    maximum = parkingLot.GetSpace();
                    maxParkingLot = parkingLot;
                }
            }
            if (maxParkingLot == ParkingLot[0])
            {
                throw new Exception("parking lot has full!");
            }

            return maxParkingLot;
        }
    }
}
