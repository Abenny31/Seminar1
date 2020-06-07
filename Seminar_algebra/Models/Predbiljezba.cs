using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seminar_algebra.Models
{
    [Table("Predbiljezba")]
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public DateTime Datum { get; set; }
        //[ForeignKey("IdSeminar")]
        public int FkSeminar { get; set; }
        //public Seminar Seminar { get; set; }
        public bool Status { get; set; }

    }
}