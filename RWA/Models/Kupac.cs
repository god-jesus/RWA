using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Kupac
    {
        public Kupac()
        {
            Racun = new HashSet<Racun>();
        }

        public int Idkupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Racun> Racun { get; set; }
    }
}
