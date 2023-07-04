using ECinema.Domain.DomainModels;
using ECinema.Domain.DTO;
using ECinema.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECinema.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Tickets");
            }


                var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                .Include("UserCart")
                .Include("UserCart.TicketInShoppingCarts")
                .Include("UserCart.TicketInShoppingCarts.Ticket")
                .FirstOrDefaultAsync();


            var userShoppingCart = loggedInUser.UserCart;
            var AllTickets = userShoppingCart.TicketInShoppingCarts.ToList();

            var allTicketPrices = AllTickets.Select(z => new {
                TicketPrice = z.Ticket.TicketPrice,
                Quantity = z.Quantity
            }).ToList(); 

            var totalPrice = 0;
            foreach (var item in allTicketPrices)
            {
                totalPrice += item.Quantity * item.TicketPrice;
            }

            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Tickets = AllTickets,
                TotalPrice = totalPrice
            };

            return View(scDto);
        }


        public async Task<IActionResult> DeleteFromShoppingCart(Guid? id)
        {


            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId) && id != null) 
            {
                var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                .Include("UserCart")
                .Include("UserCart.TicketInShoppingCarts")
                .Include("UserCart.TicketInShoppingCarts.Ticket")
                .FirstOrDefaultAsync();


                var userShoppingCart = loggedInUser.UserCart;
                var itemToDelete = userShoppingCart.TicketInShoppingCarts.Where(z => z.TicketId.Equals(id)).FirstOrDefault();

                userShoppingCart.TicketInShoppingCarts.Remove(itemToDelete);

                _context.Update(userShoppingCart);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index", "ShoppingCart");
        }

        public async Task<IActionResult> Order(Guid? id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                .Include("UserCart")
                .Include("UserCart.TicketInShoppingCarts")
                .Include("UserCart.TicketInShoppingCarts.Ticket")
                .FirstOrDefaultAsync();


                var userShoppingCart = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                _context.Add(order);
                await _context.SaveChangesAsync();


                List<TicketInOrder> ticketInOrders = new List<TicketInOrder>();

                var result = userShoppingCart.TicketInShoppingCarts.Select(z => new TicketInOrder {
                    TicketId = z.Ticket.Id,
                    OrderedTicket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order
                }).ToList();

                ticketInOrders.AddRange(result);

                foreach(var item in ticketInOrders)
                {
                    _context.Add(item);
                   
                }
                await _context.SaveChangesAsync();

                loggedInUser.UserCart.TicketInShoppingCarts.Clear();
                _context.Update(order);
                await _context.SaveChangesAsync();

            }



            return RedirectToAction("Index", "ShoppingCart");
        }

    }
}
