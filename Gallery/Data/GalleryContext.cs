using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;

namespace Gallery.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext (DbContextOptions<GalleryContext> options)
            : base(options)
        {
        }

        public DbSet<Gallery.Models.Images> Images { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Images>().ToTable("images");

            modelBuilder.Entity<Images>().Property(i => i.Id).HasColumnName("id");
            modelBuilder.Entity<Images>().Property(i => i.ImageUrl).HasColumnName("imageurl");
            modelBuilder.Entity<Images>().Property(i => i.Description).HasColumnName("description");
            modelBuilder.Entity<Images>().Property(i => i.Timestamp).HasColumnName("timestamp");
            modelBuilder.Entity<Images>().Property(i => i.Rendertime).HasColumnName("rendertime");
            modelBuilder.Entity<Images>().Property(i => i.Blurhash64).HasColumnName("blurhash64");
        }
    }
}
