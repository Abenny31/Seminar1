using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

       
    }
}