using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class SolutionConfig : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {

            builder.HasKey(p => p.SolutionId);
            builder.Property(p => p.SolutionText).IsRequired();
            builder.Property(p => p.Question).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Content).IsRequired();

            builder.HasData(
                new Solution() { SolutionId = 1, ImageUrl = "/images/asd.jpg", SolutionText = "The blue screen of death can be caused by ...", Date = new DateTime(),Question = "Blue Screen problem", ShowCase = false }
            ); ;
        }
    }
}
