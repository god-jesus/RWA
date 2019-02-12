using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Grad
    {
        public Grad()
        {
            Kupac = new HashSet<Kupac>();
        }

        public int Idgrad { get; set; }
        public string Naziv { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Kupac> Kupac { get; set; }
    }
}
