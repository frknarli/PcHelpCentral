using Entities.Models;
using System.Collections.Generic;

namespace PcHelpCentralApp.Models
{
    public class SolutionListViewModel
    {
        public IEnumerable<Solution> Solutions { get; set; } = Enumerable.Empty<Solution>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount => Solutions.Count();
    }
}
