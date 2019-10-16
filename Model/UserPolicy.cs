using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAuthentication.Model
{
    public class UserPolicy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }

        public List<UserClaim> ClaimList { get; set; }
    }
}
