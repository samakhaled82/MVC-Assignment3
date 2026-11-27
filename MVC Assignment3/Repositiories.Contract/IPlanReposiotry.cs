using MVC_Assignment2.Entities;
using MVC_Assignment2.Repositiories_Conteract;

namespace MVC_Assignment2.Repositiories_Conteract
{
    public interface IPlanReposiotry
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ca = default);

        Task<Plan?> GetByIdAsync(int id, CancellationToken ca = default);
    }
}
