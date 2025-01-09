using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class PersonnelAcceuilConfiguration : IEntityTypeConfiguration<PersonnelAccueil>
    {
        public void Configure(EntityTypeBuilder<PersonnelAccueil> builder)
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

               .Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(50);
            builder
                .ToTable("PersonnelAccueils");

        }
    }
}
