using Microsoft.EntityFrameworkCore;
using CarRecommenderIA.Models;

namespace CarrecomenderIA.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<JdmCar> JdmCars { get; set; }
}
