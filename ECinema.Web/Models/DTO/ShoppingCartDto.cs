using ECinema.Web.Models.Domain;
using System.Collections.Generic;

namespace ECinema.Web.Models.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart> Tickets { get; set; }
        public double TotalPrice { get; set; }
    }
}
