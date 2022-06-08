using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantOtomasyonu.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Galeri> Galeri { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<İletisimInfo> İletisimInfo { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
