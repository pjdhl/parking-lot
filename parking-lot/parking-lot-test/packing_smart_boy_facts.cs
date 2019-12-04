using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class packing_smart_boy_facts
    {
        private Car _car;
        public packing_smart_boy_facts()
        {
            _car = new Car();
        }

//        1: given 被聪明小弟管理的A、B两个20车位的停车场，并且停车顺序是A\B，A有10个空车位，B有11个空车位 when 我让小弟去停车 then 小弟将车停在B 我可以从小弟那里得到一张小票
        [Fact]
        public void should_get_ticket__when_parking_smart_boy_to_parking_car_and_A_B_is_manager_and_B_empty_parking_lot_more_than_A()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(10);
            var parkingLotB = new ParkingLot(11);
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            var packingSmartBoy = new ParkingSmartBoy(parkingLots);
            var ticket = packingSmartBoy.Park(_car);

            Assert.NotNull(ticket);
            Assert.Single(parkingLotB.ticketToCars);
            Assert.Empty(parkingLotB.ticketToCars);
        }

    }
}
