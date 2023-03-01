using Microsoft.AspNetCore.Identity;

namespace CafeMVC.Domain.Model
{
    public class UserCustomerDetails : IdentityUser
    {
        public Customer Customer { get; set; }

    }
}
