using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seminar_algebra.Models
{
    [Table("Zaposlenik")]
    public class Zaposlenik
    {
        [Key]
        public int IdZaposlenik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Korisnik { get; set; }
        public string Lozinka { get; set; }
    }

    
    
}