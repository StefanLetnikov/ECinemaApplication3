using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ECinema.Web.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public int MovieRating { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public string MovieImage { get; set; }



        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}
