using ECinema.Web.Models.Identity;
using System.Collections.Generic;
using System;

namespace ECinema.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }

        public ECinemaApplicationUser Owner { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
