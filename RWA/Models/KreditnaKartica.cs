using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class KreditnaKartica
    {
        public KreditnaKartica()
        {
            Racun = new HashSet<Racun>();
        }

        public int IdkreditnaKartica { get; set; }
        public string Tip { get; set; }
        public string Broj { get; set; }
        public byte IstekMjesec { get; set; }
        public short IstekGodina { get; set; }

        public virtual ICollection<Racun> Racun { get; set; }
    }
}
