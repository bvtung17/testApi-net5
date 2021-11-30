using Microsoft.EntityFrameworkCore;
using System;

namespace MyWebApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        //DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValue(DateTime.Now);
            });
            modelBuilder.Entity<ChiTietDonHang>(e =>
            {
                e.ToFunction("ChiTietDonHang");
                e.HasKey(x => new { x.MaDh, x.MaHh });
                e.HasOne(x => x.DonHang)
                .WithMany(x => x.ChiTietDonHangs)
                .HasForeignKey(x => x.MaDh);
                e.HasOne(x => x.HangHoa)
                .WithMany(x => x.ChiTietDonHangs)
                .HasForeignKey(x => x.MaHh);
            });
        }
    }
}
