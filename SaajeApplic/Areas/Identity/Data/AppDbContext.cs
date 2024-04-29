using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;
using System.Collections;
using System.Reflection.Emit;
using SaajeApplic.Models.ViewModel;

namespace SaajeApplic.Areas.Identity.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
{
    internal readonly string? FirstName;
    internal readonly string? LastName;
    internal IEnumerable? AppUsers;

    public DbSet<Commentaire> Commentaires { get; set; }

    public DbSet<Tache> Taches { get; set; }

    public DbSet<Probleme> Problemes { get; set; }

    public DbSet<Projet> Projets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<SelectListGroup>()
        .HasNoKey();
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<SaajeApplic.Models.ViewModel.ProjetCreateVM> ProjetCreateVM { get; set; } = default!;
}
