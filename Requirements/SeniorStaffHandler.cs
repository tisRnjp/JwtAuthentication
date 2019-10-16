using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthentication.Service;

namespace TokenAuthentication.Requirements
{
    public class SeniorStaffHandler : AuthorizationHandler<SeniorStaffRequirement>
    {
        private IUserDataService _userDataService;

        public SeniorStaffHandler(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SeniorStaffRequirement requirement)
        {
            var seniorDesignations = _userDataService.GetDesignations();

            if (!context.User.HasClaim(c => c.Type == "Designation" && seniorDesignations.Find(d => d.Id == Convert.ToInt32(c.Value)) != null))
            {
                return Task.CompletedTask;
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
