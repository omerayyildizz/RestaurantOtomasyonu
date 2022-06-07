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
    }
}
