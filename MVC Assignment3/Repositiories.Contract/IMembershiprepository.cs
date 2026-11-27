using System.Linq.Expressions;
using MVC_Assignment2.Context;
using MVC_Assignment2.Repositiories.Contract;
using MVC_Assignment2.Entities;

namespace MVC_Assignment2.Repositiories.Contract
{
    public interface IMembershiprepository
    {
        Task<bool>AnyAsync(Expression<Func<Membership, bool>> predicate, CancellationToken ca );
    }
}
