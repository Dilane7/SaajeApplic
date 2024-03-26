using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SaajeApplic.Models;

namespace SaajeApplic.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? LastName { get; set; }

    public List<Commentaire> commentaires { get; set; } = new List<Commentaire>();

    public List<Tache> taches { get; set; }

    public List<Projet> projets { get; set; }

    public List<Probleme> problemes { get; set; }
}

