using PcHelpCentralApp.Models;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entities.RequestParameters;
using Services.Contracts;

namespace PcHelpCentralApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _manager;

        public HomeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(SolutionRequestParameters p)
        {
            ViewData["Title"] = "Search for your problem.";

            var solutions = _manager.SolutionService.GetAllSolutionsInTrends(p, false);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.SolutionService.GetShowCaseSolutions(false).Count()
            };
            return View(new SolutionListViewModel()
            {
                Solutions = solutions,
                Pagination = pagination
            });
        }

        public IActionResult Get(SolutionRequestParameters p)
        {
            var solutions = _manager.SolutionService.GetAllSolutionsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.SolutionService.GetAllSolutions(false).Count()
            };
            return View(new SolutionListViewModel()
            {
                Solutions = solutions,
                Pagination = pagination
            });
        }
       
    }
}
