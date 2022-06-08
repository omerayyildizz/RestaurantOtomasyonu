using Microsoft.AspNetCore.Mvc;
using RestaurantOtomasyonu.Data;
using System.Linq;

namespace RestaurantOtomasyonu.ViewComponents
{
    public class KategoriListe:ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public KategoriListe(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var kategori = _db.Kategoriler.ToList();
            return View(kategori);
        }
    }
}
