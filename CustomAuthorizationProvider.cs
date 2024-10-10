using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Demo
{
    public class CustomAuthorizationProvider : DefaultAuthorizationPolicyProvider
    {
        public CustomAuthorizationProvider(IOptions<AuthorizationOptions> options) : base(options) { }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
             
            var requirement = new ReadRequirement(policyName);
            return new AuthorizationPolicyBuilder().AddRequirements(requirement).Build();
        }
    }
}
