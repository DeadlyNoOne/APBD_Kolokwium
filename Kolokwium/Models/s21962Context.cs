using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class s21962Context : DbContext
    {
        public s21962Context()
        {

        }

        public s21962Context(DbContextOptions<s21962Context> options)
            : base(options)
        {

        }

        public virtual DbSet<Musician> Musician { get; set; }
        public virtual DbSet<Musician_Track> MusicianTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<MusicLabel> MusicLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("Musician_pk");

                entity.ToTable("Musician");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.ToTable("Track");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdMusicAlbum)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.IdMusicAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Track_Album");
            });

            modelBuilder.Entity<Musician_Track>(entity =>
            {
                entity.HasKey(e => new { e.IdMusician, e.IdTrack })
                    .HasName("Musician_Track_pk");

                entity.ToTable("Musician_Track");

                entity.HasOne(d => d.IdTracks)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Track");

                entity.HasOne(d => d.IdMusicians)
                    .WithMany(p => p.Musician)
                    .HasForeignKey(d => d.IdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Musician");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.ToTable("Album");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PublishDate).HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.IdMusicLabel).HasColumnType("int")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("MusicLabel_pk");

                entity.ToTable("MusicLabel");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(20);
            });
        }
    }
}
