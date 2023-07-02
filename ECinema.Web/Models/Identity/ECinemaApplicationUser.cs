using ECinema.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace ECinema.Web.Models.Identity
{
    public class ECinemaApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}
