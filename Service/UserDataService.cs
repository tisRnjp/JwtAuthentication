using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthentication.Model;

namespace TokenAuthentication.Service
{
    public class UserDataService
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User{Id=1, Username="ranjeep", Password="password"},
                new User{Id=1, Username="penny", Password="password"}
            };
        }
    }
}
