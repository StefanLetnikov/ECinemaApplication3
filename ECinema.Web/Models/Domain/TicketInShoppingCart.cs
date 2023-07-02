using System;

namespace ECinema.Web.Models.Domain
{
    public class TicketInShoppingCart
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppinhCart { get; set; }

        public int Quantity { get; set; }
    }
}
