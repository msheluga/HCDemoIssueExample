using HotChocolate.Authorization;

namespace Demo
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(string policy)
        {
            Policy = policy;
        }
    }
}
