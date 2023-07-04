using System;

namespace ECinema.Domain.DomainModels
{
    public class TicketInShoppingCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppinhCart { get; set; }

        public int Quantity { get; set; }
    }
}
