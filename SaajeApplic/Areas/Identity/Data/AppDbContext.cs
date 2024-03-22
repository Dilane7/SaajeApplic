using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;

namespace SaajeApplic.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Commentaire> Commentaires { get; set; }

    public DbSet<Tache> Taches { get; set; }

    public DbSet<Probleme> Problemes { get; set; }

    public DbSet<Projet> Projets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
