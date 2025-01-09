using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionDesVisiteurs.Models;
namespace GestionDesVisiteurs.Models;


public class Employe
{
    [Key]
    public int Id { get; set; } // Clé primaire

    [Required]
    [StringLength(100)]
    public string Nom { get; set; }

    [Required]
    [StringLength(100)]
    public string Prenom { get; set; }

    [StringLength(150)]
    public string Poste { get; set; } // Poste de l'employé

    // Relation avec le Directeur
    [ForeignKey("Directeur")]
    public int? DirecteurId { get; set; } // Directeur superviseur
    public Directeur Directeur { get; set; } 
}


