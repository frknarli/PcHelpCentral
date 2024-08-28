using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace PcHelpCentralApp.Components
{
    public class SolutionSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public SolutionSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.SolutionService.GetAllSolutions(false).Count().ToString();
        }
    }
}
