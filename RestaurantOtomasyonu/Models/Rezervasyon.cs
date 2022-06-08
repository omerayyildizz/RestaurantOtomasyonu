using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public int Sayi { get; set; }
        [Required]
        public string Saat { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
    }
}
