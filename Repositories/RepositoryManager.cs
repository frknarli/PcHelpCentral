using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly ISolutionRepository _solutionRepository;

        public RepositoryManager(RepositoryContext context, ISolutionRepository employeeRepository)
        {
            _context = context;
            _solutionRepository = employeeRepository;
            
        }


        public ISolutionRepository Solution => _solutionRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
