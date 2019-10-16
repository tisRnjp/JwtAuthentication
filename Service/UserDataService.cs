using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthentication.Model;

namespace TokenAuthentication.Service
{
    public class UserDataService : IUserDataService
    {
        public UserDataService()
        {
        }

        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User{Id=1, Username="ranjeep", Password="password"},
                new User{Id=1, Username="penny", Password="password"}
            };
        }

        public List<UserClaim> GetClaims()
        {
            return new List<UserClaim>
            {
                new UserClaim {Id=1, ClaimName="EmployeeId"},
                new UserClaim {Id=2, ClaimName="Designation"},
                new UserClaim {Id=3, ClaimName="CustomerId"},
            };
        }

        public List<UserPolicy> GetPolicies()
        {
            return new List<UserPolicy>
            {
                new UserPolicy{Id=1, PolicyName="Staff", ClaimList = new List<UserClaim> { new UserClaim { Id = 1, ClaimName = "EmployeeId" }, new UserClaim { Id = 2, ClaimName = "Designation" } } },
                new UserPolicy{Id=2, PolicyName="User", ClaimList=new List<UserClaim>{new UserClaim {Id=3, ClaimName="CustomerId"}, new UserClaim {Id=1, ClaimName="EmployeeId"}}}
            };
        }

        public List<Designation> GetDesignations()
        {
            return new List<Designation>
            {
                new Designation{Id=1, DesignationName="CEO"},
                new Designation{Id=1, DesignationName="Senior Manager"},
                new Designation{Id=1, DesignationName="HR Manager"},
                new Designation{Id=1, DesignationName="Janitor"},
                new Designation{Id=1, DesignationName="Cashier"},
                new Designation{Id=1, DesignationName="Staff"}
            };
        }
    }
}
