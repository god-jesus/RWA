using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RWA
{
    public partial class AdventureWorksOBPContext : DbContext
    {
        public AdventureWorksOBPContext()
        {
        }

        public AdventureWorksOBPContext(DbContextOptions<AdventureWorksOBPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Komercijalist> Komercijalist { get; set; }
        public virtual DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<Potkategorija> Potkategorija { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Stavka> Stavka { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IRADOSEVICW10\\SQLEXPRESS;Database=AdventureWorksOBP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.HasKey(e => e.Iddrzava);

                entity.Property(e => e.Iddrzava).HasColumnName("IDDrzava");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasKey(e => e.Idgrad);

                entity.Property(e => e.Idgrad).HasColumnName("IDGrad");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasKey(e => e.Idkategorija);

                entity.Property(e => e.Idkategorija).HasColumnName("IDKategorija");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Komercijalist>(entity =>
            {
                entity.HasKey(e => e.Idkomercijalist);

                entity.Property(e => e.Idkomercijalist).HasColumnName("IDKomercijalist");

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(50);
            });

            modelBuilder.Entity<KreditnaKartica>(entity =>
            {
                entity.HasKey(e => e.IdkreditnaKartica);

                entity.Property(e => e.IdkreditnaKartica).HasColumnName("IDKreditnaKartica");

                entity.Property(e => e.Broj)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasKey(e => e.Idkupac);

                entity.Property(e => e.Idkupac).HasColumnName("IDKupac");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(25);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Kupac)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Kupac_Grad");
            });

            modelBuilder.Entity<Potkategorija>(entity =>
            {
                entity.HasKey(e => e.Idpotkategorija)
                    .HasName("PK_PotkategorijaProizvoda");

                entity.Property(e => e.Idpotkategorija).HasColumnName("IDPotkategorija");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Potkategorija)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Potkategorija_Kategorija");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasKey(e => e.Idproizvod);

                entity.Property(e => e.Idproizvod).HasColumnName("IDProizvod");

                entity.Property(e => e.Boja).HasMaxLength(15);

                entity.Property(e => e.BrojProizvoda)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.CijenaBezPdv)
                    .HasColumnName("CijenaBezPDV")
                    .HasColumnType("money");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PotkategorijaId).HasColumnName("PotkategorijaID");

                entity.HasOne(d => d.Potkategorija)
                    .WithMany(p => p.Proizvod)
                    .HasForeignKey(d => d.PotkategorijaId)
                    .HasConstraintName("FK_Proizvod_Potkategorija");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.HasKey(e => e.Idracun);

                entity.Property(e => e.Idracun).HasColumnName("IDRacun");

                entity.Property(e => e.BrojRacuna)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DatumIzdavanja).HasColumnType("datetime");

                entity.Property(e => e.Komentar).HasMaxLength(128);

                entity.Property(e => e.KomercijalistId).HasColumnName("KomercijalistID");

                entity.Property(e => e.KreditnaKarticaId).HasColumnName("KreditnaKarticaID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.HasOne(d => d.Komercijalist)
                    .WithMany(p => p.Racun)
                    .HasForeignKey(d => d.KomercijalistId)
                    .HasConstraintName("FK_Racun_Komercijalist");

                entity.HasOne(d => d.KreditnaKartica)
                    .WithMany(p => p.Racun)
                    .HasForeignKey(d => d.KreditnaKarticaId)
                    .HasConstraintName("FK_Racun_KreditnaKartica");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Racun)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Racun_Kupac");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasKey(e => e.Idstavka);

                entity.Property(e => e.Idstavka).HasColumnName("IDStavka");

                entity.Property(e => e.CijenaPoKomadu).HasColumnType("money");

                entity.Property(e => e.PopustUpostocima)
                    .HasColumnName("PopustUPostocima")
                    .HasColumnType("money");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.Property(e => e.UkupnaCijena).HasColumnType("numeric(38, 6)");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Stavka)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stavka_Proizvod");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.Stavka)
                    .HasForeignKey(d => d.RacunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stavka_Racun");
            });
        }
    }
}
