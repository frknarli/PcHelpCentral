using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class SolutionRepository : RepositoryBase<Solution>, ISolutionRepository
    {
        public SolutionRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneSolution(Solution solution) => Create(solution);

        public void DeleteOneSolution(Solution solution) => Remove(solution);


        public IQueryable<Solution> GetAllSolutions(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Solution> GetAllSolutionsInTrends(SolutionRequestParameters p, bool trackChanges)
        {

            return _context
               .Solution
               .ToPaginate(p.PageNumber, p.PageSize)
               .Where(p => p.ShowCase.Equals(true));
      
        }

        public IQueryable<Solution> GetAllSolutionsWithDetails(SolutionRequestParameters p)
        {

            return _context
            .Solution
            .FilteredBySearchTerm(p.SearchTerm)
            .ToPaginate(p.PageNumber, p.PageSize);
              


        }

        public IQueryable<Solution> GetAllSolutionsWithDetailsForAdmin(SolutionRequestParameters p)
        {
            return _context
                .Solution
                .FilteredBySearchTermForAdminPage(p.SearchTerm)
                .ToPaginate(p.PageNumber, p.PageSize);
        }

        public Solution? GetOneSolution(int id, bool trackChanges)
        {
            return FindByCondition(p => p.SolutionId.Equals(id), trackChanges);
        }

        public IQueryable<Solution> GetShowCaseSolutions(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneSolution(Solution entity) => Update(entity);
   

    }
}
