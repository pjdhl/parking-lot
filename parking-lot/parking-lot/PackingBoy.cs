using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class PackingBoy
    {
        public List<ParkingLot> PackingLot { get; set; }

        public PackingBoy()
        {
            var parkingLotA = new ParkingLot();
            var parkingLots = new List<ParkingLot>(){parkingLotA};
            PackingLot = parkingLots;
        }

        public object Park(Car car)
        {

            var ticket = this.PackingLot[0].Park(car);
            return ticket;
        }
    }
}
