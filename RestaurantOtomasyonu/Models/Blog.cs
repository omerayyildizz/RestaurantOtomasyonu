using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Blog
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Resim { get; set; }
        
        public bool Onay { get; set; }
        [Required]
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }


    }
}
