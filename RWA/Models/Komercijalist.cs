using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Komercijalist
    {
        public Komercijalist()
        {
            Racun = new HashSet<Racun>();
        }

        public int Idkomercijalist { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool? StalniZaposlenik { get; set; }

        public virtual ICollection<Racun> Racun { get; set; }
    }
}
