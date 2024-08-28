using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISolutionService
    {
        IEnumerable<Solution> GetAllSolutions(bool trackChanges);
        IEnumerable<Solution> GetLastestSolutions(int n, bool trackChanges);
        IEnumerable<Solution> GetAllSolutionsWithDetails(SolutionRequestParameters p);
        IEnumerable<Solution> GetAllSolutionsWithDetailsForAdmin(SolutionRequestParameters p);
        IEnumerable<Solution> GetAllSolutionsInTrends(SolutionRequestParameters p, bool trackChanges);
        IEnumerable<Solution> GetShowCaseSolutions(bool trackChanges);
        Solution? GetOneSolution(int id, bool trackChanges);
        void CreateSolution(SolutionDtoForInsertion productDto);
        void UpdateOneSolution(SolutionDtoForUpdate productDto);
        void DeleteOneSolution(int id);
        SolutionDtoForUpdate GetOneSolutionForUpdate(int id, bool trackChanges);


    }
}
