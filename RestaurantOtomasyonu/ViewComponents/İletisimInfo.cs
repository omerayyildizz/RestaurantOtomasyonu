using Microsoft.AspNetCore.Mvc;
using RestaurantOtomasyonu.Data;
using System.Linq;

namespace RestaurantOtomasyonu.ViewComponents
{
    public class İletisimInfo:ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public İletisimInfo(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var iletisim = _db.İletisimInfo.ToList();
            return View(iletisim);
        }
    }
}
