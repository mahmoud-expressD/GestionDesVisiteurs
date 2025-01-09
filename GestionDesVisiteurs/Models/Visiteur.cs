
using System;
using System.ComponentModel.DataAnnotations;

namespace GestionDesVisiteurs.Models
{
    public class Visiteur
    {
        public int Id { get; set; }

      
        public string Nom { get; set; }

        
        public string Prenom { get; set; }

        
        public string Email { get; set; }
        public string Telephone { get; set; }

      
        public string NumeroCIN { get; set; }  

      
       

        public DateTime DateVisite { get; set; }


        [DataType(DataType.Time)] 
        public DateTime HeureEntree { get; set; } 
        public DateTime? HeureSortie { get; set; } 
        public bool EstValide { get; set; }
    
        

    
       
    }
}
