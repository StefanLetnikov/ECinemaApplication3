using ECinema.Web.Models.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ECinema.Web.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ECinemaApplicationUser User { get; set; }


        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}
