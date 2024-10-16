using Demo;
using Demo.Database;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddPooledDbContextFactory<AdventureWorks2022Context>(
    options => options.UseSqlServer("Data Source=DESKTOP-92K3UB0;" +
  "Initial Catalog=AdventureWorks2022;" +
  "Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True"));


builder.Services.AddCors(options =>
{
    options.AddPolicy(config.GetValue("Cors:PolicyName", "DefaultCorsPolicy"),
    builder =>
    {
        builder.WithOrigins(config.GetValue<string[]>("Cors:AllowedOrigins", new string[] { "*" }))
               .WithHeaders(config.GetValue<string[]>("Cors:AllowedHeaders", new string[] { "*" }))
               .WithMethods(config.GetValue<string[]>("Cors:AllowedMethods", new string[] { "*" }));
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpLogging(o => { });
builder.Services.AddSingleton<IAuthorizationHandler, ReadHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationProvider>();

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKey"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidIssuer = "https://auth.chillicream.com",
                ValidAudience = "https://graphql.chillicream.com",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
            };
    });
builder.Services.AddAuthorization();

builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .RegisterDbContext<AdventureWorks2022Context>(DbContextKind.Pooled)
    .AddProjections()
    .AddFiltering()
    .AddInstrumentation()                            
    .AddSorting()
    .AddHttpRequestInterceptor<HttpRequestInterceptor>()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseHttpLogging();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(config.GetValue("Cors:PolicyName", "DefaultCorsPolicy"));
app.MapGraphQL().WithOptions(new GraphQLServerOptions()
{
    Tool = { ServeMode = GraphQLToolServeMode.Embedded },
    EnableBatching = config.GetValue<bool>("GraphQLOptions:EnableBatching"),
});


app.Run();
