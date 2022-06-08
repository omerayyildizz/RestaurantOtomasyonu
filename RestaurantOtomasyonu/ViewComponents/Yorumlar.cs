using Microsoft.AspNetCore.Mvc;
using RestaurantOtomasyonu.Data;
using System.Linq;

namespace RestaurantOtomasyonu.ViewComponents
{
    public class Yorumlar : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public Yorumlar(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var yorum = _db.Blog.Where(x=>x.Onay).ToList();
            return View(yorum);
        }
    }
}
