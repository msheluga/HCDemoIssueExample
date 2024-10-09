﻿using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Demo
{
    public class HttpRequestIntercepter: DefaultHttpRequestInterceptor
    {
        private readonly IPolicyEvaluator _policyEvaluator;
        private readonly IAuthorizationPolicyProvider _authorizationPolicyProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;



        public HttpRequestIntercepter(
            IHttpContextAccessor httpContextAccessor,
            IPolicyEvaluator policyEvaluator,
            IAuthorizationPolicyProvider authorizationPolicyProvider,
            ILogger logger)
        { 
            _httpContextAccessor = httpContextAccessor;
            _policyEvaluator = policyEvaluator;
            _authorizationPolicyProvider = authorizationPolicyProvider;
        }

        public override async ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken)
        {
            var queryRequest = requestBuilder.Create();
            //inspeact the context and look at the 
            var identity = new ClaimsIdentity();
            //go get the claims 
            if (context.Request.Headers.TryGetValue("Authorization", out var authValue))
            {
                //validate the claim against the value
                if (AuthenticationHeaderValue.Parse(authValue) is { Parameter: { } parameters })
                {
                    PopulateClaims(context, requestExecutor, requestBuilder);
                }
            }
            await _policyEvaluator.AuthenticateAsync(await _authorizationPolicyProvider.GetDefaultPolicyAsync(), context);
            await base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }

        private void PopulateClaims(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder)
        {
            var appId = context.Request.Headers["Authorization"];
            if (appId.ToString() == null)
            {
                return;
            }
            var userIds = new List<string>
            {
                "C8104FC7-8643-4908-B88E-61AA6A3FCF36",
                "4E74C96B-D428-4A76-A518-E412C770D951",
                "7D4F3DEA-92AA-4B98-B5EB-887A246FA566"
            };
            if (!userIds.Contains(appId.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return;
            }

            var principal = context.User.Identity as ClaimsIdentity;
            var claims = new List<Claim>()
            {
                new Claim (ClaimTypes.Name,appId.ToString()),               
                new Claim("AdventureWorks.Person.Address.Read", "AddressID, City, PostalCode, rowguid")               
            };
            principal.AddClaims(claims);            
        }
    }
}
