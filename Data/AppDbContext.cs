using Microsoft.EntityFrameworkCore;
using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Data;

public class AppDbContext : DbContext
{
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Constituent> Constituents => Set<Constituent>();
    public DbSet<Case> Cases => Set<Case>();
    public DbSet<Interaction> Interactions => Set<Interaction>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}
