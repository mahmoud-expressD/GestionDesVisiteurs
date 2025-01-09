using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class DirecteurConfiguration : IEntityTypeConfiguration<Directeur>
    {
        public void Configure(EntityTypeBuilder<Directeur> builder)
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
                .Property(p => p.Departement)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .ToTable("Directeurs");
        }
    }
}
