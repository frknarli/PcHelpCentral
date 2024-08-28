using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class SolutionRepositoryExtension
    {

        public static IQueryable<Solution> FilteredBySearchTermForAdminPage(this IQueryable<Solution> solutions, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return solutions;
            else
                return solutions.Where(prd => prd.SolutionText.ToLower()
                .Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Solution> FilteredBySearchTerm(this IQueryable<Solution> solutions, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return solutions;
            else
                return solutions.Where(prd => prd.Question.ToLower()
                .Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Solution> ToPaginate(this IQueryable<Solution> solutions,
            int pageNumber, int pageSize)
        {

                return solutions
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
 
            
        }
    }
}
