using MVC_Assignment2.Context;
using MVC_Assignment2.Repositiories.Contract;
using MVC_Assignment2.Entities;
using Microsoft.EntityFrameworkCore;

namespace MVC_Assignment2.Repositiories
{
    public class Membershiprepository : IMembershiprepository
    {
        private readonly GymDbContext _dbContext;

        public Membershiprepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<Membership, bool>> predicate, CancellationToken ca)
        {
            return await _dbContext.Memberships.AnyAsync(predicate, ca);
        }
    }
}
