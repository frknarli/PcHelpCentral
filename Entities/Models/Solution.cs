using Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Solution
{
    public int SolutionId { get; set; }
    
    public string? SolutionText { get; set; } = string.Empty;
    public string? Question { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now.Date;
    public String? ImageUrl { get; set; }
    public bool ShowCase { get; set; }
    public string? Content { get; set; } = string.Empty;


}
