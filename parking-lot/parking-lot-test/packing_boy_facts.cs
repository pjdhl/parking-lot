using System;
using System.Collections;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class packing_boy_facts
    {
        private Car _car;

        public packing_boy_facts()
        {
            _car = new Car();
        }

//        1: given 一个小弟管理的A停车场 when 我让小弟去停车 then 我可以从小弟那里得到一张小票
        [Fact]
        public void should_return_ticket_from_packing_boy_when_let_boy_to_packing_car()
        {

            var parkingLots = new List<ParkingLot>();
            var parkingLot = new ParkingLot();
            parkingLots.Add(parkingLot);
            var packingBoy = new PackingBoy(parkingLots);

            var car = new Car();
            var ticket = packingBoy.Park(car);
            Assert.NotNull(ticket);
        }

//        2: given 被小弟管理的A、B两个空的停车场，并且停车顺序是A\B when 我让小弟去停车 then 小弟将车停在A 我可以从小弟那里得到一张小票

        [Fact]
        public void should_return_ticket_when_let_boy_to_parking_car_with_manager_parking_lot_A_and_B_order_A_first()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            var ticket = packingBoy.Park(_car);

            Assert.NotNull(ticket);
            Assert.Single(parkingLotA.ticketToCars);
            Assert.Empty(parkingLotB.ticketToCars);
        }

//        3: given 被小弟管理的AB两个停车场，A是满的停车场、B是空的停车场，并且停车顺序是A\B when 我让小弟去停车 then 小弟将车停在B 我可以从小弟那里得到一张小票
        [Fact]
        public void should_return_ticket_and_car_exist_B_when_parking_boy_to_parking_car_and_A_is_full()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            for (int i = 0; i < 20; i++)
            {
                packingBoy.Park(new Car());
            }

            var ticket = packingBoy.Park(_car);
            Assert.NotNull(ticket);
            Assert.Equal(20, parkingLotA.ticketToCars.Count);
            Assert.Single(parkingLotB.ticketToCars);
        }

//        4: given 被小弟管理的AB两个停车场，AB是满的停车场，并且停车顺序是A\B when 我让小弟去停车 then 提示停车场已满
        [Fact]
        public void should_not_save_car_when_parking_boy_to_parking_car_and_A_and_is_full()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            for (int i = 0; i < 40; i++)
            {
                packingBoy.Park(new Car());
            }

            Assert.Equal(20, parkingLotA.ticketToCars.Count);
            Assert.Equal(20, parkingLotB.ticketToCars.Count);
            var exception = Assert.Throws<Exception>(() => packingBoy.Park(new Car()));
            Assert.Equal("ParkingLot is full", exception.Message);
        }

//        6: given 被小弟管理的AB两个停车场，A还有空的，B是满的停车场，并且停车顺序是A\B when 小弟去停车 then 小弟将车停在A,我可以从小弟得到一张票
        [Fact]
        public void should_not_save_car_when_parking_boy_to_parking_car_and_B_and_is_full()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            for (int i = 0; i < 20; i++)
            {
                parkingLotB.Park(new Car());
            }

            var ticket = packingBoy.Park(_car);
            Assert.NotNull(ticket);
            Assert.Equal(20, parkingLotB.ticketToCars.Count);
            Assert.Single(parkingLotA.ticketToCars);
        }


//        1: given 被小弟管理的一个停车场和一张有效小票 when 我让小弟去取车 then 我可以得到我的车
        [Fact]
        public void should_get_my_car_when_parking_boy_to_get_car_with_a_validate_ticket()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            parkingLots.Add(parkingLotA);

            var packingBoy = new PackingBoy(parkingLots);
            var ticket = packingBoy.Park(_car);

            var myCar = packingBoy.GetCar(ticket);
            Assert.NotNull(myCar);
            Assert.Same(_car, myCar);
        }

//        2: given 被小弟管理的AB两个停车场和一张有效小票(车停在B停车场) when 我让小弟去取车 then 我可以得到我的车
        [Fact]
        public void should_get_my_car_when_parking_boy_to_get_car_with_a_validate_ticket_with_A_and_B_parking()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            for (int i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
            }

            var ticket = packingBoy.Park(_car);

            var myCar = packingBoy.GetCar(ticket);

            Assert.NotNull(myCar);
            Assert.Same(_car, myCar);
        }

//        3: given 被小弟管理的AB两个停车场和一张白纸 when 我让小弟去取车 then 提示小票无效
        [Fact]
        public void should_get_message_when_parking_boy_to_get_car_with_a_invalid_ticket_with_A_and_B_parking()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);

            var invalidTicket = new object();
            var exception = Assert.Throws<Exception>(() => { packingBoy.GetCar(invalidTicket); });
            Assert.Equal("Invalid ticket!", exception.Message);
        }

//        4: given 被小弟管理的AB两个停车场和一张用过的小票 when 我让小弟去取车 then 提示小票无效

        [Fact]
        public void should_get_message_when_parking_boy_to_get_car_with_a_used_ticket_with_A_and_B_parking()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var packingBoy = new PackingBoy(parkingLots);
            var ticketed = packingBoy.Park(_car);
            var car = packingBoy.GetCar(ticketed);
            Assert.NotNull(car);

            var exception = Assert.Throws<Exception>(() => { packingBoy.GetCar(ticketed); });
            Assert.Equal("Invalid ticket!", exception.Message);
        }

//        5: given 不被小弟管理的A停车场和一张有效小票 when 我让小弟去取车 then 提示小票无效
        [Fact]
        public void should_get_message_when_parking_boy_to_get_car_with_a_invalid_ticket_with_dont_manager_A_parking()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            parkingLots.Add(parkingLotB);

            var ticket = parkingLotA.Park(_car);
            var packingBoy = new PackingBoy(parkingLots);

            var exception = Assert.Throws<Exception>(() => { packingBoy.GetCar(ticket); });
            Assert.Equal("Invalid ticket!", exception.Message);
        }
    }
}
