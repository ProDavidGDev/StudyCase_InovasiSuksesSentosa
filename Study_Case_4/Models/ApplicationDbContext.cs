using Microsoft.EntityFrameworkCore;
using Study_Case_4.Models;

namespace Study_Case_4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ListNama> ListNama { get; set; }

        public DbSet<Absen> Absensi { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Absen>()
                .HasKey(a => new { a.NIK, a.TanggalAbsen });
        }
    }
}