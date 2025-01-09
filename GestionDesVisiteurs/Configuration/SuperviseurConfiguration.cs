using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class SuperviseurConfiguration : IEntityTypeConfiguration<Superviseur>
    {
        public void Configure(EntityTypeBuilder<Superviseur> builder)
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
                .Property(p => p.Cin)
                .IsRequired()
                .HasMaxLength(50);
            builder
               .Property(p => p.Prenom)
               .IsRequired()
               .HasMaxLength(50);
            builder
               .Property(p => p.Telephone)
               .IsRequired()
               .HasMaxLength(50);
            builder
                
               .Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(50);
            builder
                .ToTable("Superviseurs");

        }
    }
}
