using System;
using System.Collections.Generic;
using EfLinqConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<asortyment> asortyments { get; set; }

    public virtual DbSet<asortyment_idx> asortyment_idxes { get; set; }

    public virtual DbSet<bitwy> bitwies { get; set; }

    public virtual DbSet<deliveryorder> deliveryorders { get; set; }

    public virtual DbSet<drukarka> drukarkas { get; set; }

    public virtual DbSet<hangar> hangars { get; set; }

    public virtual DbSet<klasy> klasies { get; set; }

    public virtual DbSet<klienci> kliencis { get; set; }

    public virtual DbSet<klienci_idx> klienci_idxes { get; set; }

    public virtual DbSet<kursy> kursies { get; set; }

    public virtual DbSet<laptop> laptops { get; set; }

    public virtual DbSet<loty> loties { get; set; }

    public virtual DbSet<mapujmiastum> mapujmiasta { get; set; }

    public virtual DbSet<okrety> okreties { get; set; }

    public virtual DbSet<pc> pcs { get; set; }

    public virtual DbSet<pilot> pilots { get; set; }

    public virtual DbSet<pracownicy> pracownicies { get; set; }

    public virtual DbSet<produkt> produkts { get; set; }

    public virtual DbSet<projekty> projekties { get; set; }

    public virtual DbSet<psiaki_a> psiaki_as { get; set; }

    public virtual DbSet<psiaki_b> psiaki_bs { get; set; }

    public virtual DbSet<psiaki_c_psy> psiaki_c_psies { get; set; }

    public virtual DbSet<psiaki_c_sztuczki> psiaki_c_sztuczkis { get; set; }

    public virtual DbSet<psiaki_c_zrecznosci> psiaki_c_zrecznoscis { get; set; }

    public virtual DbSet<realizacje> realizacjes { get; set; }

    public virtual DbSet<skill> skills { get; set; }

    public virtual DbSet<skutki> skutkis { get; set; }

    public virtual DbSet<stanowiska> stanowiskas { get; set; }

    public virtual DbSet<transakcje> transakcjes { get; set; }

    public virtual DbSet<transakcje_idx> transakcje_idxes { get; set; }

    public virtual DbSet<uczestnicy> uczestnicies { get; set; }

    public virtual DbSet<uczestnicyaktualnie> uczestnicyaktualnies { get; set; }

    public virtual DbSet<udzial> udzials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<asortyment>(entity =>
        {
            entity.HasKey(e => e.id_asortymentu).HasName("asortyment_pkey");

            entity.ToTable("asortyment");

            entity.Property(e => e.id_asortymentu).HasMaxLength(3);
            entity.Property(e => e.nazwa_asortymentu).HasMaxLength(36);
        });

        modelBuilder.Entity<asortyment_idx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("asortyment_idx");

            entity.Property(e => e.id_asortymentu).HasMaxLength(3);
            entity.Property(e => e.nazwa_asortymentu).HasMaxLength(36);
        });

        modelBuilder.Entity<bitwy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bitwy");

            entity.Property(e => e.data).HasMaxLength(20);
            entity.Property(e => e.nazwa).HasMaxLength(20);
        });

        modelBuilder.Entity<deliveryorder>(entity =>
        {
            entity.HasKey(e => e.orderid).HasName("deliveryorders_pkey");

            entity.Property(e => e.orderid).UseIdentityAlwaysColumn();
            entity.Property(e => e.amount).HasColumnType("money");
            entity.Property(e => e.modtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.orderdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ordernum).HasMaxLength(20);
            entity.Property(e => e.placeholder)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Placeholder'::bpchar")
                .IsFixedLength();
            entity.Property(e => e.reference).HasMaxLength(64);
        });

        modelBuilder.Entity<drukarka>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("drukarka");

            entity.Property(e => e.typ).HasMaxLength(20);
        });

        modelBuilder.Entity<hangar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hangar");

            entity.Property(e => e.plane).HasMaxLength(20);
        });

        modelBuilder.Entity<klasy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("klasy");

            entity.Property(e => e.klasa).HasMaxLength(20);
            entity.Property(e => e.kraj).HasMaxLength(20);
            entity.Property(e => e.typ).HasMaxLength(20);
        });

        modelBuilder.Entity<klienci>(entity =>
        {
            entity.HasKey(e => e.id_klienta).HasName("klienci_pkey");

            entity.ToTable("klienci");

            entity.HasIndex(e => e.nip, "klienci_nip_key").IsUnique();

            entity.Property(e => e.id_klienta).HasMaxLength(9);
            entity.Property(e => e.imie).HasMaxLength(14);
            entity.Property(e => e.kod).HasMaxLength(6);
            entity.Property(e => e.miejscowosc).HasMaxLength(24);
            entity.Property(e => e.nazwisko).HasMaxLength(24);
            entity.Property(e => e.nip).HasMaxLength(14);
            entity.Property(e => e.ulica).HasMaxLength(79);
            entity.Property(e => e.wojewodztwo).HasMaxLength(19);
        });

        modelBuilder.Entity<klienci_idx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("klienci_idx");

            entity.Property(e => e.id_klienta).HasMaxLength(9);
            entity.Property(e => e.imie).HasMaxLength(14);
            entity.Property(e => e.kod).HasMaxLength(6);
            entity.Property(e => e.miejscowosc).HasMaxLength(24);
            entity.Property(e => e.nazwisko).HasMaxLength(24);
            entity.Property(e => e.nip).HasMaxLength(14);
            entity.Property(e => e.ulica).HasMaxLength(79);
            entity.Property(e => e.wojewodztwo).HasMaxLength(19);
        });

        modelBuilder.Entity<kursy>(entity =>
        {
            entity.HasKey(e => e.kod).HasName("kursy_pkey");

            entity.ToTable("kursy");

            entity.HasIndex(e => e.nazwa, "kursy_nazwa_key").IsUnique();

            entity.Property(e => e.nazwa).HasMaxLength(50);
        });

        modelBuilder.Entity<laptop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("laptop");

            entity.Property(e => e.ekran).HasPrecision(10, 1);
            entity.Property(e => e.szybkosc).HasPrecision(10, 2);
        });

        modelBuilder.Entity<loty>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("loty");

            entity.Property(e => e.dokad).HasMaxLength(3);
            entity.Property(e => e.linie).HasMaxLength(3);
            entity.Property(e => e.odloty).HasPrecision(0);
            entity.Property(e => e.przyloty).HasPrecision(0);
            entity.Property(e => e.zkad).HasMaxLength(3);
        });

        modelBuilder.Entity<mapujmiastum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.forma_niepoprawna).HasMaxLength(20);
            entity.Property(e => e.forma_poprawna).HasMaxLength(20);
        });

        modelBuilder.Entity<okrety>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("okrety");

            entity.Property(e => e.klasa).HasMaxLength(20);
            entity.Property(e => e.nazwa).HasMaxLength(20);
        });

        modelBuilder.Entity<pc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pc");

            entity.Property(e => e.szybkosc).HasPrecision(10, 2);
        });

        modelBuilder.Entity<pilot>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.pilot1)
                .HasMaxLength(20)
                .HasColumnName("pilot");
        });

        modelBuilder.Entity<pracownicy>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pracownicy_pkey");

            entity.ToTable("pracownicy");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.dod_funkc).HasColumnType("money");
            entity.Property(e => e.nazwisko).HasMaxLength(20);
            entity.Property(e => e.placa).HasColumnType("money");
            entity.Property(e => e.stanowisko).HasMaxLength(10);
            entity.Property(e => e.zatrudniony).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.stanowiskoNavigation).WithMany(p => p.pracownicies)
                .HasForeignKey(d => d.stanowisko)
                .HasConstraintName("pracownicy_stanowisko_fkey");

            entity.HasOne(d => d.szefNavigation).WithMany(p => p.InverseszefNavigation)
                .HasForeignKey(d => d.szef)
                .HasConstraintName("pracownicy_szef_fkey");
        });

        modelBuilder.Entity<produkt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("produkt");

            entity.Property(e => e.producent).HasMaxLength(20);
            entity.Property(e => e.typ).HasMaxLength(20);
        });

        modelBuilder.Entity<projekty>(entity =>
        {
            entity.HasKey(e => e.id).HasName("projekty_pkey");

            entity.ToTable("projekty");

            entity.HasIndex(e => e.nazwa, "projekty_nazwa_key").IsUnique();

            entity.Property(e => e.id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(10L, 10L, null, null, null, null);
            entity.Property(e => e.datarozp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.datazakonczfakt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.datazakonczplan).HasColumnType("timestamp without time zone");
            entity.Property(e => e.nazwa).HasMaxLength(20);
            entity.Property(e => e.stawka).HasColumnType("money");

            entity.HasOne(d => d.kierownikNavigation).WithMany(p => p.projekties)
                .HasForeignKey(d => d.kierownik)
                .HasConstraintName("projekty_kierownik_fkey");
        });

        modelBuilder.Entity<psiaki_a>(entity =>
        {
            entity.HasKey(e => e.pies_kod).HasName("psiaki_a_pkey");

            entity.ToTable("psiaki_a");

            entity.Property(e => e.pies_kod).ValueGeneratedNever();
            entity.Property(e => e.buda).HasMaxLength(10);
            entity.Property(e => e.pies_imie).HasMaxLength(10);
            entity.Property(e => e.sztuczki_nazwa_1).HasMaxLength(15);
            entity.Property(e => e.sztuczki_nazwa_2).HasMaxLength(15);
            entity.Property(e => e.sztuczki_nazwa_3).HasMaxLength(15);
        });

        modelBuilder.Entity<psiaki_b>(entity =>
        {
            entity.HasKey(e => new { e.pies_kod, e.sztuczki_kod }).HasName("pk_psiaki_b");

            entity.ToTable("psiaki_b");

            entity.Property(e => e.buda).HasMaxLength(10);
            entity.Property(e => e.pies_imie).HasMaxLength(10);
            entity.Property(e => e.sztuczki_nazwa).HasMaxLength(15);
        });

        modelBuilder.Entity<psiaki_c_psy>(entity =>
        {
            entity.HasKey(e => e.pies_kod).HasName("psiaki_c_psy_pkey");

            entity.ToTable("psiaki_c_psy");

            entity.Property(e => e.pies_kod).ValueGeneratedNever();
            entity.Property(e => e.buda).HasMaxLength(10);
            entity.Property(e => e.pies_imie).HasMaxLength(10);
        });

        modelBuilder.Entity<psiaki_c_sztuczki>(entity =>
        {
            entity.HasKey(e => e.sztuczki_kod).HasName("psiaki_c_sztuczki_pkey");

            entity.ToTable("psiaki_c_sztuczki");

            entity.Property(e => e.sztuczki_kod).ValueGeneratedNever();
            entity.Property(e => e.sztuczki_nazwa).HasMaxLength(15);
        });

        modelBuilder.Entity<psiaki_c_zrecznosci>(entity =>
        {
            entity.HasKey(e => new { e.pies_kod, e.sztuczki_kod, e.sztuczki_zrecznosc }).HasName("pk_psiaki_c_zrecznosc");

            entity.ToTable("psiaki_c_zrecznosci");

            entity.HasOne(d => d.pies_kodNavigation).WithMany(p => p.psiaki_c_zrecznoscis)
                .HasForeignKey(d => d.pies_kod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("psiaki_c_zrecznosci_pies_kod_fkey");

            entity.HasOne(d => d.sztuczki_kodNavigation).WithMany(p => p.psiaki_c_zrecznoscis)
                .HasForeignKey(d => d.sztuczki_kod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("psiaki_c_zrecznosci_sztuczki_kod_fkey");
        });

        modelBuilder.Entity<realizacje>(entity =>
        {
            entity.HasKey(e => new { e.idproj, e.idprac }).HasName("realizacje_pkey");

            entity.ToTable("realizacje");

            entity.Property(e => e.godzin).HasDefaultValueSql("8");

            entity.HasOne(d => d.idpracNavigation).WithMany(p => p.realizacjes)
                .HasForeignKey(d => d.idprac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("realizacje_idprac_fkey");

            entity.HasOne(d => d.idprojNavigation).WithMany(p => p.realizacjes)
                .HasForeignKey(d => d.idproj)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("realizacje_idproj_fkey");
        });

        modelBuilder.Entity<skill>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.pilot).HasMaxLength(20);
            entity.Property(e => e.plane).HasMaxLength(20);
        });

        modelBuilder.Entity<skutki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("skutki");

            entity.Property(e => e.bitwa).HasMaxLength(20);
            entity.Property(e => e.efekt).HasMaxLength(20);
            entity.Property(e => e.okret).HasMaxLength(20);
        });

        modelBuilder.Entity<stanowiska>(entity =>
        {
            entity.HasKey(e => e.nazwa).HasName("stanowiska_pkey");

            entity.ToTable("stanowiska");

            entity.Property(e => e.nazwa).HasMaxLength(10);
            entity.Property(e => e.placa_max).HasColumnType("money");
            entity.Property(e => e.placa_min).HasColumnType("money");
        });

        modelBuilder.Entity<transakcje>(entity =>
        {
            entity.HasKey(e => e.id_transakcji).HasName("transakcje_pkey");

            entity.ToTable("transakcje");

            entity.Property(e => e.id_transakcji).HasMaxLength(13);
            entity.Property(e => e.asortyment).HasMaxLength(3);
            entity.Property(e => e.ilosc).HasPrecision(5, 2);
            entity.Property(e => e.klient).HasMaxLength(9);

            entity.HasOne(d => d.asortymentNavigation).WithMany(p => p.transakcjes)
                .HasForeignKey(d => d.asortyment)
                .HasConstraintName("transakcje_asortyment_fkey");

            entity.HasOne(d => d.klientNavigation).WithMany(p => p.transakcjes)
                .HasForeignKey(d => d.klient)
                .HasConstraintName("transakcje_klient_fkey");
        });

        modelBuilder.Entity<transakcje_idx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transakcje_idx");

            entity.Property(e => e.asortyment).HasMaxLength(3);
            entity.Property(e => e.id_transakcji).HasMaxLength(13);
            entity.Property(e => e.ilosc).HasPrecision(5, 2);
            entity.Property(e => e.klient).HasMaxLength(9);
        });

        modelBuilder.Entity<uczestnicy>(entity =>
        {
            entity.HasKey(e => e.pesel).HasName("uczestnicy_pkey");

            entity.ToTable("uczestnicy");

            entity.Property(e => e.pesel)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.miasto)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Poznań'::character varying");
            entity.Property(e => e.nazwisko).HasMaxLength(20);
        });

        modelBuilder.Entity<uczestnicyaktualnie>(entity =>
        {
            entity.HasKey(e => e.pesel).HasName("uczestnicyaktualnie_pkey");

            entity.ToTable("uczestnicyaktualnie");

            entity.Property(e => e.pesel)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.miasto)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Poznań'::character varying");
            entity.Property(e => e.nazwisko).HasMaxLength(20);
        });

        modelBuilder.Entity<udzial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("udzial");

            entity.Property(e => e.status).HasMaxLength(20);
            entity.Property(e => e.uczestnik)
                .HasMaxLength(11)
                .IsFixedLength();

            entity.HasOne(d => d.kursNavigation).WithMany()
                .HasForeignKey(d => d.kurs)
                .HasConstraintName("udzial_kurs_fkey");

            entity.HasOne(d => d.uczestnikNavigation).WithMany()
                .HasForeignKey(d => d.uczestnik)
                .HasConstraintName("udzial_uczestnik_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
