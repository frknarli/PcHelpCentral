using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SolutionManager : ISolutionService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public SolutionManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateSolution(SolutionDtoForInsertion solutionDto)
        {
            Solution solution = _mapper.Map<Solution>(solutionDto);

            _manager.Solution.Create(solution);
            _manager.Save();
        }

        public void DeleteOneSolution(int id)
        {
            Solution solution = GetOneSolution(id, false);
            if (solution is not null)
            {
                _manager.Solution.DeleteOneSolution(solution);
                _manager.Save();
            }
        }

        public IEnumerable<Solution> GetAllSolutions(bool trackChanges)
        {
            return _manager.Solution.GetAllSolutions(trackChanges);
        }

        public IEnumerable<Solution> GetAllSolutionsInTrends(SolutionRequestParameters p, bool trackChanges)
        {
            return _manager.Solution.GetAllSolutionsInTrends(p, trackChanges);
        }

        public IEnumerable<Solution> GetAllSolutionsWithDetails(SolutionRequestParameters p)
        {
            return _manager.Solution.GetAllSolutionsWithDetails(p);
        }

        public IEnumerable<Solution> GetAllSolutionsWithDetailsForAdmin(SolutionRequestParameters p)
        {
            return _manager.Solution.GetAllSolutionsWithDetailsForAdmin(p);
        }

        public IEnumerable<Solution> GetLastestSolutions(int n, bool trackChanges)
        {
            return _manager
                .Solution
                .FindAll(trackChanges)
                .OrderByDescending(prd => prd.SolutionId)
                .Take(n);
        }

        public Solution? GetOneSolution(int id, bool trackChanges)
        {
            var solution = _manager.Solution.GetOneSolution(id, trackChanges);
            if (solution is null)
            {
                throw new Exception("SolutionText not found!");
            }
            return solution;
        }

        public SolutionDtoForUpdate GetOneSolutionForUpdate(int id, bool trackChanges)
        {
            var solution = GetOneSolution(id, trackChanges);
            var solutionDto = _mapper.Map<SolutionDtoForUpdate>(solution);
            return solutionDto;
        }

        public IEnumerable<Solution> GetShowCaseSolutions(bool trackChanges)
        {
            var solution = _manager.Solution.GetShowCaseSolutions(trackChanges);
            return solution;
        }

        public void UpdateOneSolution(SolutionDtoForUpdate solutionDto)
        {
            var entity = _mapper.Map<Solution>(solutionDto);
            _manager.Solution.UpdateOneSolution(entity);
            _manager.Save();
        }


    }
}
