using Microsoft.EntityFrameworkCore;
using MyMicroservice.Domain.Entities;

namespace MyMicroservice.Infrastructure.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tio> Tios => Set<Tio>();
}