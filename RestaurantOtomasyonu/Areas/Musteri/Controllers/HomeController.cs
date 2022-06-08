using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using RestaurantOtomasyonu.Data;
using RestaurantOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOtomasyonu.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IToastNotification _toast;
        private readonly IWebHostEnvironment _webHe;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IToastNotification toast,IWebHostEnvironment webHe)
        {
            _logger = logger;
            _db = db;
            _toast = toast;
            _webHe = webHe;
        }

        public IActionResult Index()
        {
            var menu = _db.Menuler.Where(x=>x.Ozel).ToList();
            return View(menu);
        }
        public IActionResult KategoriDetay(int? id)
        {
            var menu = _db.Menuler.Where(x => x.KategoriId == id).ToList();
            ViewBag.KategoriId = id;
            return View(menu);
        }
        public IActionResult Iletisim()
        {
            return View();
        }

        // POST: Admin/Iletisim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iletisim([Bind("Id,AdSoyad,Email,Telefon,Mesaj")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                iletisim.Tarih = DateTime.Now;
                _db.Add(iletisim);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Mesajınız iletilmiştir teşekkür ederiz...");
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }
        public IActionResult Blog()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(_webHe.WebRootPath, @"Site\blog");
                    var ext = Path.GetExtension(files[0].FileName);
                    if (blog.Resim != null)
                    {
                        var imgPath = Path.Combine(_webHe.WebRootPath, blog.Resim.TrimStart('\\'));
                        if (System.IO.File.Exists(imgPath))
                        {
                            System.IO.File.Delete(imgPath);
                        }
                    }
                    using (var filesStream = new FileStream(Path.Combine(upload, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }
                    blog.Resim = @"\Site\blog\" + fileName + ext;
                }
                _db.Add(blog);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Yorumunuz iletilmiştir.");
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }
        public IActionResult Hakkimizda()
        {
            var hakkimizda = _db.Hakkimizda.ToList();
            return View(hakkimizda);
        }
        public IActionResult Galeri()
        {
            var galeri = _db.Galeri.ToList();
            return View(galeri);
        }
        public IActionResult Menu()
        {
            var menu = _db.Menuler.ToList();
            return View(menu);
        }
        public IActionResult Rezervasyon()
        {
            return View();
        }

        // POST: Admin/Rezervasyon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon([Bind("Id,AdSoyad,Email,Telefon,Sayi,Saat,Tarih")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _db.Add(rezervasyon);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Teşekkür ederiz rezervasyonunuz başarılı bir şekilde oluşmuştur Keyifli vakit geçirmeniz dileğinizle...");
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
