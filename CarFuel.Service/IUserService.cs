using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Service
{
    public interface IUserService
    {

        bool IsLoggedIn();
        string CurrentUserId();

    }
}
