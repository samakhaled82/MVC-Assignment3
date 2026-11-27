using Microsoft.EntityFrameworkCore;
using MVC_Assignment2.Context;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Repositiories_Conteract;

namespace MVC_Assignment2.Repositiories
{
    public class PlanReposiotry : IPlanReposiotry
    {
        private readonly GymDbContext _dbContext;

        //private GymDbContext dbContext = new GymDbContext();

        public PlanReposiotry(GymDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ca=default)
        { 

            var plans = await _dbContext.Plans.AsNoTracking().ToListAsync(ca);
            return plans;
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ca = default)
        {
            return await _dbContext.Plans.FindAsync([id] , ca);
        }
    }
}
