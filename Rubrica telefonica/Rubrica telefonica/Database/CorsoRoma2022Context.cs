using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rubrica_telefonica.Database
{
    public partial class CorsoRoma2022Context : DbContext
    {
        public CorsoRoma2022Context()
        {
        }

        public CorsoRoma2022Context(DbContextOptions<CorsoRoma2022Context> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Chiamatum> Chiamata { get; set; } = null!;
        public virtual DbSet<Contatto> Contattos { get; set; } = null!;
        public virtual DbSet<Numero> Numeros { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sqlsviluppostep.database.windows.net,1433;Initial Catalog=CorsoRoma2022;User ID=sqladmin;Password=Password.123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Chiamatum>(entity =>
            {
                entity.HasKey(e => e.IdChiamata);

                entity.Property(e => e.FineChiamata).HasColumnType("datetime");

                entity.Property(e => e.InizioChiamata).HasColumnType("datetime");

                entity.HasOne(d => d.IdChiamanteNavigation)
                    .WithMany(p => p.ChiamatumIdChiamanteNavigations)
                    .HasForeignKey(d => d.IdChiamante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chiamata_Numero");

                entity.HasOne(d => d.IdRiceventeNavigation)
                    .WithMany(p => p.ChiamatumIdRiceventeNavigations)
                    .HasForeignKey(d => d.IdRicevente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chiamata_Ricevente");
            });

            modelBuilder.Entity<Contatto>(entity =>
            {
                entity.HasKey(e => e.IdContatto);

                entity.ToTable("Contatto");

                entity.Property(e => e.Alias).HasMaxLength(50);

                entity.Property(e => e.Cognome).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(319);

                entity.Property(e => e.IdCellulare).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdTelefonoFisso).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.Contattos)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Contatto_Numero");
            });

            modelBuilder.Entity<Numero>(entity =>
            {
                entity.HasKey(e => e.IdNumero);

                entity.ToTable("Numero");

                entity.Property(e => e.NumeroTelefono).HasMaxLength(15);
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
