using System;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class packing_bot_facts
    {
        //        1: given 一个小弟管理的A停车场 when 我让机器人去停车 then 我可以从小弟那里得到一张小票
        [Fact]
        public void should_return_ticket_from_packing_bot_when_let_boy_to_packing_car()
        {

            var parkingLots = new List<ParkingLot>();
            var parkingLot = new ParkingLot(20);
            parkingLots.Add(parkingLot);

            var parkingBot = new ParkingBot(parkingLots);
            var ticket = parkingBot.Park(new Car());

            Assert.NotNull(ticket);
        }

        // 2. given 一个小弟管理的A/B空的停车场 when 我让机器人去停车 then 小弟将车停在A停车场
        [Fact]
        public void should_park_car_to_A_when_parking_bot_to_parking_car()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(20);
            var parkingLotB = new ParkingLot(20);
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var parkingBot = new ParkingBot(parkingLots);
            parkingBot.Park(new Car());

            Assert.Single(parkingLotA.ticketToCars);
        }

        // 3. given 一个小弟管理的A满的停车场 B空的停车场 when 我让机器人去停车 then 机器人将车停在B停车场
        [Fact]
        public void should_park_car_to_B_when_parking_bot_to_parking_car()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(20);
            var parkingLotB = new ParkingLot(20);
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            for (int i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
            }

            var parkingBot = new ParkingBot(parkingLots);
            parkingBot.Park(new Car());

            Assert.Equal(20, parkingLotA.ticketToCars.Count);
            Assert.Single(parkingLotB.ticketToCars);
        }

        // 4. given 一个小弟管理的A/B满的停车场 when 我让机器人去停车 then 机器人提示停车场已满

        [Fact]
        public void should_get_message_when_parking_bot_to_parking_car()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(20);
            var parkingLotB = new ParkingLot(20);
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);
            for (int i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
            }

            for (int i = 0; i < 20; i++)
            {
                parkingLotB.Park(new Car());
            }

            var parkingBot = new ParkingBot(parkingLots);


            var exception = Assert.Throws<Exception>(() => parkingBot.Park(new Car()));
            Assert.Equal("ParkingLot is full", exception.Message);
        }

        // 5. given 一个小弟管理的A/B的停车场和一个不被机器人管理的停车场 when 我让机器人去停车 then 机器人将车停在A

        [Fact]
        public void should_park_car_to_A_when_parking_bot_to_parking_car_with_bot_manage_A_and_B_without_C()
        {
            var parkingLots = new List<ParkingLot>();
            var parkingLotA = new ParkingLot(20);
            var parkingLotB = new ParkingLot(20);
            var parkingLotC = new ParkingLot(20);
            parkingLots.Add(parkingLotA);
            parkingLots.Add(parkingLotB);

            var parkingBot = new ParkingBot(parkingLots);
            parkingBot.Park(new Car());

            Assert.Single(parkingLotA.ticketToCars);
        }
    }
}
