using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class İletisimInfo
    {
        [Key]
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
