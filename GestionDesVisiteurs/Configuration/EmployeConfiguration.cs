using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .UseIdentityColumn();
            builder
                .Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Prenom)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Poste)
                .HasMaxLength(100);
            builder
                .HasOne(p => p.Directeur)
                .WithMany(d => d.Employes)
                .HasForeignKey(p => p.DirecteurId)
                .OnDelete(DeleteBehavior.SetNull);
            builder
                .ToTable("Employes");
        }
    }
}
