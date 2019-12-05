using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBot: IParkMethod
    {
        private readonly List<ParkingLot> _parkingLots;

        public ParkingBot(List<ParkingLot> parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public virtual object Park(Car car)
        {
            foreach (var parkingLot in _parkingLots)
            {
                if (parkingLot.IsHasSpace())
                {
                    return parkingLot.Park(car);
                }
            }
            throw new Exception("ParkingLot is full");
        }
    }
}
