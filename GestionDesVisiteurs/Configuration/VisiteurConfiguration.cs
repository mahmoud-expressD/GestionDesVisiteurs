using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class VisiteurConfiguration : IEntityTypeConfiguration<Visiteur>
    {
        public void Configure(EntityTypeBuilder<Visiteur> builder)
        {
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .UseIdentityColumn();
            builder
                .Property(p => p.DateVisite)
                .IsRequired();
            builder
               .Property(p => p.HeureEntree)
               .IsRequired();
               
            builder
               .Property(p => p.HeureSortie)
               .IsRequired();
                
            builder
               .Property(p => p.Nom)
               .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(p => p.Prenom)
               .IsRequired()
               .HasMaxLength(50);
            builder
               .Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(50);
            builder
               .Property(p => p.Telephone)
               .IsRequired()
               .HasMaxLength(50);
            builder
                .Property(p => p.NumeroCIN)
                .IsRequired()
                .HasMaxLength(50);
            builder
               .Property(p => p.EstValide)
               .IsRequired()
               .HasMaxLength(50);
            builder
                .ToTable("Visiteurs");
        }

     
    }

   
    
}
