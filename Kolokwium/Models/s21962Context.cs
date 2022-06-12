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
    }
}
