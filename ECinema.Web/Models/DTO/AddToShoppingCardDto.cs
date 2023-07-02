using ECinema.Web.Models.Domain;
using System;

namespace ECinema.Web.Models.DTO
{
    public class AddToShoppingCardDto
    {
        public Ticket SelectedTicket { get; set; }
        public Guid TicketId { get; set; }
        public int Quantity { get; set; }
    }
}