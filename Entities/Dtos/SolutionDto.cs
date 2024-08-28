using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record SolutionDto
    {
        public int SolutionId { get; init; }
        
        [Required(ErrorMessage = "Solution must be written.")]
        public string? SolutionText { get; init; } = string.Empty;
        
        [Required(ErrorMessage = "Question must be written.")]
        public string? Question { get; init; } = string.Empty;

        [Required(ErrorMessage = "Date must be written.")]
        public DateTime Date { get; init; } = DateTime.Now.Date;
        public String? ImageUrl { get; set; }
        public string? Content { get; set; } = string.Empty;

    }
}
