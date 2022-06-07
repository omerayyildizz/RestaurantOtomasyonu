using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOtomasyonu.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public bool Ozel { get; set; }
        public double Fiyat { get; set; }
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
    }
}
