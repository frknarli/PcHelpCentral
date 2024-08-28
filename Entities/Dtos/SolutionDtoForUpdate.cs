using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record SolutionDtoForUpdate : SolutionDto
    {
        public bool Showcase { get; set; }
    }
}
