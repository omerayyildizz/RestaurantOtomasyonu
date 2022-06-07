using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string KategoriAdi { get; set; }
    }
}
