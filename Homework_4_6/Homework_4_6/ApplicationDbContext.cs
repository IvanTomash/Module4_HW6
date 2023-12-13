using Homework_4_6.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6;

internal class ApplicationDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Location> Locations { get; set; }

    public ApplicationDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=SNEGPAD\SQL2023;Initial Catalog=Homework6;Integrated Security=True");
    }
}
