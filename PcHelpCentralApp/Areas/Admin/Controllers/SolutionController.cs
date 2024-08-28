using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using PcHelpCentralApp.Models;
using System.IO;
using Spire.Doc;

namespace PcHelpCentralApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SolutionController : Controller
    {
        private readonly IServiceManager _manager;

        public SolutionController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Get([FromQuery] SolutionRequestParameters p)
        {
            ViewData["Title"] = "Solution";

            var solutions = _manager.SolutionService.GetAllSolutionsWithDetailsForAdmin(p);
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

        public IActionResult Create()
        {
            TempData["info"] = "Lütfen bilgileri girin.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] SolutionDtoForInsertion solutionDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                solutionDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.SolutionService.CreateSolution(solutionDto);
                TempData["success"] = $"{solutionDto.SolutionText} oluþturuldu.";
                return RedirectToAction("Get");
            }
            return View();
        }


        public IActionResult Update([FromRoute(Name = "id")] int id)
        {

            var model = _manager.SolutionService.GetOneSolutionForUpdate(id, false);
            ViewData["Title"] = model?.SolutionText;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromForm] SolutionDtoForUpdate solutionDto, IFormFile? file)
        {
            var model = _manager.SolutionService.GetOneSolution(id, false);
            if (ModelState.IsValid)
            {
                
                if (file != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    solutionDto.ImageUrl = String.Concat("/images/", file.FileName);
                }
                else
                {
                    solutionDto.ImageUrl = model.ImageUrl;
                }

                int count = _manager.SolutionService.GetShowCaseSolutions(false).Count();
                if (count < 16)
                {
                    _manager.SolutionService.UpdateOneSolution(solutionDto);
                    return RedirectToAction("Get");
                }
                else
                {                  
                    if (solutionDto.Showcase == false)
                    {
                        _manager.SolutionService.UpdateOneSolution(solutionDto);
                        return RedirectToAction("Get");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "You can't pick 16 trend at most.");
                    }
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.SolutionService.DeleteOneSolution(id);
            TempData["danger"] = "Solution bilgisi silindi.";
            return RedirectToAction("Get");
        }
    }
}