using Microsoft.AspNetCore.Mvc;

namespace PcHelpCentralApp.Components
{
    public class SolutionFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
