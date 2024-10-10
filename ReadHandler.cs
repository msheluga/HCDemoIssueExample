using HotChocolate.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Demo
{
    public class ReadHandler : AuthorizationHandler<ReadRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const int DatabaseNameIndex = 0;
        private const int SchemaNameIndex = 1;
        private const int TableNameIndex = 2;
        private const int FieldNameIndex = 3;
        private const int OperationTypeIndex = 4;

        private const string operation = "Read";
        public ReadHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadRequirement requirement)
        {
            if (TryGetClaimsPrincipal(requirement, out ClaimsPrincipal principal))
            {
                context.Succeed(requirement);
            }
            else
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private bool TryGetClaimsPrincipal(ReadRequirement requirement, out ClaimsPrincipal principal)
        {
            principal = new ClaimsPrincipal();
            if (_httpContextAccessor?.HttpContext?.User != null)
            {
                principal = _httpContextAccessor.HttpContext.User;
                var databaseName = GetDatabaseName(requirement);
                var schemaName = GetSchemaName(requirement);
                var tableName = GetTableName(requirement);
                var fieldName = GetFieldName(requirement);
               
                var claim = (principal.FindFirst(c => c.Type != null &&
                c.Type.Equals($"{databaseName}.{schemaName}.{tableName}.{operation}", StringComparison.OrdinalIgnoreCase)));

                if (claim != null 
                    && claim.Value.Contains(fieldName))
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        private static string GetDatabaseName(ReadRequirement requirement)
        {
            return GetFragment(DatabaseNameIndex, requirement);
        }

        private static string GetSchemaName(ReadRequirement requirement)
        {
            return GetFragment(SchemaNameIndex, requirement);
        }

        private static string GetTableName(ReadRequirement requirement)
        {
            return GetFragment(TableNameIndex, requirement);
        }

        private static string GetFieldName(ReadRequirement requirement)
        {
            return GetFragment(FieldNameIndex, requirement);
        }

        private static string GetFragment(int index, ReadRequirement requirement)
        {
            var split = requirement.Claim.Split('.');
            return split.Length >= index + 1 ? split[index] : null;
        }
    }
}
