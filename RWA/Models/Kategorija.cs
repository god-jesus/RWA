using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Potkategorija = new HashSet<Potkategorija>();
        }

        public int Idkategorija { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Potkategorija> Potkategorija { get; set; }
    }
}
