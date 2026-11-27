using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Assignment2.Context;
using MVC_Assignment2.Repositiories;
using MVC_Assignment2.Repositiories.Contract;
using MVC_Assignment2.Repositiories_Conteract;

namespace MVC_Assignment2.Controllers
{
    public class PlanController : Controller
    {


        #region Old ways before (DI)

        //private GymDbContext dbContext = new GymDbContext(); 
        //private PlanReposiotry planRepository = new PlanReposiotry(CancellationToken ct);
        //private IPlanReposiotry planRepository = new PlanReposiotrycc; 
        #endregion

        private readonly IPlanReposiotry _planReposiotry;
        private readonly IMembershiprepository _membershipRepository;

        public PlanController(IPlanReposiotry planReposiotry ,IMembershiprepository membershipRepository)
        {
            _planReposiotry = planReposiotry;
            _membershipRepository = membershipRepository;
        }


        public async Task<IActionResult> Index()
        {
            //var plans = await dbContext.Plans.ToListAsync();
            var plans = await _planReposiotry.GetAllAsync();

            return View(plans);
        }


        public IActionResult IndexTest()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken ca)
        {
            var plan = await _planReposiotry.GetByIdAsync(id, ca);

            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "Plan not found or is inactive.";
                return RedirectToAction(nameof(Index));
            }

            var hasActiveMemberships = await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ca);

            if (hasActiveMemberships)
            {
                TempData["ErrorMessage"] = "Cannot edit this plan because it has active memberships.";
                return RedirectToAction(nameof(Index));
            }

            return View(plan);

        }         

    }
}
