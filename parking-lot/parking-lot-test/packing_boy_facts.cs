using System;
using System.Collections;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class packing_boy_facts
    {
//        1: given 一个小弟管理的A停车场 when 我让小弟去停车 then 我可以从小弟那里得到一张小票
        [Fact]
        public void should_return_ticket_from_packing_boy_when_let_boy_to_packing_car()
        {
            var packingBoy = new PackingBoy();
            var car = new Car();
            var ticket = packingBoy.Park(car);
            Assert.NotNull(ticket);
        }

//        2: given 被小弟管理的A、B两个空的停车场，并且停车顺序是A\B when 我让小弟去停车 then 小弟将车停在A 我可以从小弟那里得到一张小票

//        [Fact]
//        public void should_return_ticket_when_let_boy_to_parking_car_
    }
}
