using Sklep_z_grami.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Models
{
    public class Shop : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo sklepu")]
        public string Logo { get; set; }
        [Display(Name = "Pełna nazwa sklepu")]
        public string Nazwa { get; set; }
        [Display(Name = "Lokalizacja Sklepu")]
        public string Lokalizacja { get; set; }

        //Relation
        public List<Game> Games { get; set; }
    }
}
