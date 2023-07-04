using ECinema.Domain.DomainModels;
using System.Collections.Generic;

namespace ECinema.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart> Tickets { get; set; }
        public double TotalPrice { get; set; }
    }
}
