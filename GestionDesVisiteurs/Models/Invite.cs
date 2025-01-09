using System;
using System.ComponentModel.DataAnnotations;
namespace GestionDesVisiteurs.Models;

public class Invite
{
    [Key]
    public int Id { get; set; } // Clé primaire

    [Required]
    [StringLength(100)]
    public string Nom { get; set; }

    [Required]
    [StringLength(100)]
    public string Prenom { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateInvitation { get; set; } // Date de l'invitation

    [Required]
    [StringLength(300)]
    public string Motif { get; set; } // Motif de la visite
}
