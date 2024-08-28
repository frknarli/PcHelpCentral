using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class SolutionRequestParameters : RequestParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public SolutionRequestParameters() : this(1, 8)
        {

        }
        public SolutionRequestParameters(int pageNumber = 1, int pageSize = 8)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
//eğer default constructor istenirse 1,6 lık bir sayfa getilrir.