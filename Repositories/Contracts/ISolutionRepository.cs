using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISolutionRepository : IRepositoryBase<Solution>
    {
        IQueryable<Solution> GetAllSolutions(bool trackChanges);
        IQueryable<Solution> GetAllSolutionsWithDetails(SolutionRequestParameters p);
        IQueryable<Solution> GetAllSolutionsWithDetailsForAdmin(SolutionRequestParameters p);
        IQueryable<Solution> GetAllSolutionsInTrends(SolutionRequestParameters p, bool trackChanges);
        IQueryable<Solution> GetShowCaseSolutions(bool trackChanges);
        public Solution? GetOneSolution(int id, bool trackChanges);
        void CreateOneSolution(Solution solution);
        void DeleteOneSolution(Solution solution);
        void UpdateOneSolution(Solution entity);
    }
}
