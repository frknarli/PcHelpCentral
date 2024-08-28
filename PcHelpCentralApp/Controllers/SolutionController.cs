using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;
using PcHelpCentralApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace PcHelpCentralApp.Controllers
{

    public class SolutionController : Controller
    {
        private readonly IServiceManager _manager;

        public SolutionController(IServiceManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index(SolutionRequestParameters p)
        {
            ViewData["Title"] = "Solutions to problems.";

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

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.SolutionService.GetOneSolution(id, false);
            ViewData["Title"] = model?.SolutionText;
            return View(model);
        }


    }
}
