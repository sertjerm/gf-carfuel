using CarFuel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFuel.web.Models
{
    public class UserService : IUserService
    {

        public string CurrentUserId()
        {
            return HttpContext.Current.User.Identity.Name;//.GetUserId();
        }

        public bool IsLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}