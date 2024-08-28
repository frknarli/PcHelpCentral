using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ISolutionService _solutionService;
        private readonly IAuthService _authService;

        public ServiceManager(ISolutionService solutionService, IAuthService authService)
        {
            _solutionService = solutionService;
            _authService = authService;
        }

        public ISolutionService SolutionService => _solutionService;

        public IAuthService AuthService => _authService;
    }
}
