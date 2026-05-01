using Microsoft.EntityFrameworkCore;
using SatelliteTracker.Models;
namespace SatelliteTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Satellite> Satellites { get; set; }
}
