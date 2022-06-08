using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih{ get; set; }
    }
}
