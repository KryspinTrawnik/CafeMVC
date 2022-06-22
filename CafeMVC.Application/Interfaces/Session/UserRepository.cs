using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces.Session
{
    public class UserRepository 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public void LogCurrentUser()
        {
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;

            // ...
        }
    }
}
