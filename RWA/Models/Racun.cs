﻿using System;
using System.Collections.Generic;

namespace RWA
{
    public partial class Racun
    {
        public Racun()
        {
            Stavka = new HashSet<Stavka>();
        }

        public int Idracun { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string BrojRacuna { get; set; }
        public int KupacId { get; set; }
        public int? KomercijalistId { get; set; }
        public int? KreditnaKarticaId { get; set; }
        public string Komentar { get; set; }

        public virtual Komercijalist Komercijalist { get; set; }
        public virtual KreditnaKartica KreditnaKartica { get; set; }
        public virtual Kupac Kupac { get; set; }
        public virtual ICollection<Stavka> Stavka { get; set; }
    }
}
