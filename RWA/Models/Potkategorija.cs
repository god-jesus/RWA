using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Potkategorija
    {
        public Potkategorija()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        public int Idpotkategorija { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Proizvod> Proizvod { get; set; }
    }
}
