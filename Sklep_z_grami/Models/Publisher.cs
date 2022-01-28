using Sklep_z_grami.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Models
{
    public class Publisher : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Wymagane logo")]
        public string ImageURL { get; set; }

        [Display(Name = "Nazwa firmy")]
        [Required(ErrorMessage = "Wymagana nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Krótki opis")]
        [Required(ErrorMessage = "Wymagany opis")]
        public string Opis { get; set; }

        public List<Game> Games { get; set; }
    }
}
