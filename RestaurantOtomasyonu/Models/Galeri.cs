using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Galeri
    {
        [Key]
        public int Id { get; set; }
        public string Resim { get; set; }

    }
}
