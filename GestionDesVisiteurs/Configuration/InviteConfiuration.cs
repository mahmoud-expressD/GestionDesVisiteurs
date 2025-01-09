using GestionDesVisiteurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDesVisiteurs.Configuration
{
    public class InviteConfiguration : IEntityTypeConfiguration<Invite>
    {
        public void Configure(EntityTypeBuilder<Invite> builder)
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
                .Property(p => p.DateInvitation)
                .IsRequired();
            builder
                .Property(p => p.Motif)
                .IsRequired()
                .HasMaxLength(300);
            builder
                .ToTable("Invites");
        }
    }
}
