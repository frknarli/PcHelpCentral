using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace PcHelpCentralApp.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowcaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(string page = "default")
        {
            var solutions = _manager.SolutionService.GetShowCaseSolutions(false);
            return page.Equals("default")
                ?  View(solutions)
                :  View("List",solutions);
        }
    }
}