using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class AdministrateurConfiguration : IEntityTypeConfiguration<Administrateur>
    {
        public void Configure(EntityTypeBuilder<Administrateur> builder)
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
                .ToTable("Administrateurs");
           

        }

        private void HasMaxlength(int v)
        {
            throw new NotImplementedException();
        }
    }
}
