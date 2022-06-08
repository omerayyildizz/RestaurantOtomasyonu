using System.ComponentModel.DataAnnotations;

namespace RestaurantOtomasyonu.Models
{
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string Aciklama { get; set; }
    }
}
