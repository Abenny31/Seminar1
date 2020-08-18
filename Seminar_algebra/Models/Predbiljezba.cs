using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seminar_algebra.Models
{
    [Table("Predbiljezba")]
    public class Predbiljezba
    {
        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        [Key]
        public int IdPredbiljezba { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Ime { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Prezime { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Adresa { get; set; }
        
        [Required]
        public string Mjesto { get; set; }
        public DateTime Datum { get; set; }
        //[ForeignKey("IdSeminar")]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Seminar")]
        public int FkSeminar { get; set; }
        //public Seminar Seminar { get; set; }
        
        public bool Status { get; set; }

        [ForeignKey("FkSeminar")]
        public virtual Seminar Seminar { get; set; }

    }
}