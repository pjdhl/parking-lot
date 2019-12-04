using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class packing_smart_boy_facts
    {
        private Car _car;
        private int parkingSize = 20;
        public packing_smart_boy_facts()
        {
            _car = new Car();
        }

//        1: given 被聪明小弟管理的A、B两个20车位的停车场，并且停车顺序是A\B，A有10个空车位，B有11个空车位 when 我让小弟去停车 then 小弟将车停在B 我可以从小弟那里得到一张小票
        [Fact]
        public void should_get_ticket__when_parking_smart_boy_to_parking_car_and_A_B_is_manager_and_B_empty_parking_lot_more_than_A()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(parkingSize);
            var parkingLotB = new ParkingLot(parkingSize);

            for (int i = 0; i < 10; i++)
            {
                parkingLotA.Park(new Car());
            }

            for (int i = 0; i < 9; i++)
            {
                parkingLotB.Park(new Car());
            }
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            var packingSmartBoy = new ParkingSmartBoy(parkingLots);

            var ticket = packingSmartBoy.Park(_car);

            Assert.NotNull(ticket);
            Assert.Equal(10, parkingLotB.ticketToCars.Count);
            Assert.Equal(10, parkingLotA.ticketToCars.Count);
        }

//        2: given 被聪明小弟管理的A、B两个20车位的停车场，并且停车顺序是A\B，A有10个空车位，B有10个空车位 when 我让小弟去停车 then 小弟将车停在A 我可以从小弟那里得到一张小票
        [Fact]
        public void should_get_ticket__when_parking_smart_boy_to_parking_car_and_A_B_is_manager_and_B_empty_parking_lot_equal_A()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(parkingSize);
            var parkingLotB = new ParkingLot(parkingSize);

            for (int i = 0; i < 10; i++)
            {
                parkingLotA.Park(new Car());
            }

            for (int i = 0; i < 10; i++)
            {
                parkingLotB.Park(new Car());
            }
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            var packingSmartBoy = new ParkingSmartBoy(parkingLots);

            var ticket = packingSmartBoy.Park(_car);

            Assert.NotNull(ticket);
            Assert.Equal(10, parkingLotB.ticketToCars.Count);
            Assert.Equal(11, parkingLotA.ticketToCars.Count);
        }

//        3: given 被聪明小弟管理的A10车位（空）、B20车位的停车场，并且停车顺序是A\B，A有10个空车位，B有11个空车位 when 我让小弟去停车 then 小弟将车停在B 我可以从小弟那里得到一张小票
        [Fact]
        public void should_get_ticket__when_parking_smart_boy_to_parking_car_and_A_init_is_10_B_init_is_20_is_manager_and_B_empty_parking_lot_more_than_A()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(10);
            var parkingLotB = new ParkingLot(parkingSize);

            for (int i = 0; i < 9; i++)
            {
                parkingLotB.Park(new Car());
            }
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            var packingSmartBoy = new ParkingSmartBoy(parkingLots);

            var ticket = packingSmartBoy.Park(_car);

            Assert.NotNull(ticket);
            Assert.Equal(10, parkingLotB.ticketToCars.Count);
            Assert.Empty(parkingLotA.ticketToCars);
        }
    }
}
