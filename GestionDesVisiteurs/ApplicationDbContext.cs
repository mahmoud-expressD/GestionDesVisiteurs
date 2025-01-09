using GestionDesVisiteurs.Configuration;
using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GestionDesVisiteurs
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Visiteur> Visiteurs { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Superviseur> Superviseurs { get; set; }
        public DbSet<PersonnelAccueil> PersonnelAcceuils { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Directeur> Directeurs { get; set; }
        public DbSet<Invite> invites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                 .ApplyConfiguration(new VisiteurConfiguration());
            builder
                 .ApplyConfiguration(new AdministrateurConfiguration());
            builder
                 .ApplyConfiguration(new SuperviseurConfiguration());
            builder
                 .ApplyConfiguration(new PersonnelAcceuilConfiguration());
            builder
                .ApplyConfiguration(new EmployeConfiguration());
            builder
                .ApplyConfiguration(new DirecteurConfiguration());
            builder
                .ApplyConfiguration(new InviteConfiguration());

        }

    }
}

