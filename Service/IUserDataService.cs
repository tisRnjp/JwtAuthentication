using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthentication.Model;

namespace TokenAuthentication.Service
{
    public interface IUserDataService
    {
        List<User> GetUsers();
        List<UserClaim> GetClaims();
        List<UserPolicy> GetPolicies();
        List<Designation> GetDesignations();
    }
}
