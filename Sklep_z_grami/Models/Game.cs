using Sklep_z_grami.Data;
using Sklep_z_grami.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Models
{
    public class Game 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Okładka")]
        [Required(ErrorMessage = "Wymagana okładka")]
        public string ImageURL { get; set; }
        [Display(Name = "Nazwa Gry")]
        [Required(ErrorMessage = "Wymagana nazwa")]
        public string Nazwa { get; set; }
        [Display(Name = "Krótki opis")]
        [Required(ErrorMessage = "Wymagany opis")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Wymagana cena")]
        public double Cena { get; set; }
        [Required(ErrorMessage = "Wymagana kategoria")]
        public Category Category { get; set; }

        //Relation
     

        //Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

    }
}
