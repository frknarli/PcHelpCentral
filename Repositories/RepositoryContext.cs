using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories;
public class RepositoryContext : IdentityDbContext<IdentityUser> 
{
    public DbSet<Solution> Solution { get; set; }
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
