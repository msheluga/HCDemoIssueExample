using AdventureWorks;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Demo
{
    public class Query
    {
        private readonly IDbContextFactory<AdventureWorks2022Context> _dbContextFactory;
        public Query(IDbContextFactory<AdventureWorks2022Context> factory)
        {
            _dbContextFactory = factory;
        }


        public async Task<IQueryable<Address>> getAddress()
        {
            var context = await _dbContextFactory.CreateDbContextAsync();
            return context.Addresses;

        }

    }
}
