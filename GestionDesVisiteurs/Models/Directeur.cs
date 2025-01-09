using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GestionDesVisiteurs.Models;

public class Directeur
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
    [StringLength(150)]
    public string Departement { get; set; } // Département associé

    // Liste des employés supervisés
    public ICollection<Employe> Employes { get; set; }
}

