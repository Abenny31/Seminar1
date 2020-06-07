using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seminar_algebra.Models
{
    [Table("Seminar")]
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }
        //public int SeminarID
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }

    }
}