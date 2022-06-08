using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOtomasyonu.Data;
using RestaurantOtomasyonu.Models;

namespace RestaurantOtomasyonu.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class İletisimInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public İletisimInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/İletisimInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.İletisimInfo.ToListAsync());
        }

        // GET: Admin/İletisimInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletisimInfo = await _context.İletisimInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (İletisimInfo == null)
            {
                return NotFound();
            }

            return View(İletisimInfo);
        }

        // GET: Admin/İletisimInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/İletisimInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adres,Email,Telefon")] İletisimInfo İletisimInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(İletisimInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(İletisimInfo);
        }

        // GET: Admin/İletisimInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletisimInfo = await _context.İletisimInfo.FindAsync(id);
            if (İletisimInfo == null)
            {
                return NotFound();
            }
            return View(İletisimInfo);
        }

        // POST: Admin/İletisimInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adres,Email,Telefon")] İletisimInfo İletisimInfo)
        {
            if (id != İletisimInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(İletisimInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!İletisimInfoExists(İletisimInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(İletisimInfo);
        }

        // GET: Admin/İletisimInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletisimInfo = await _context.İletisimInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (İletisimInfo == null)
            {
                return NotFound();
            }

            return View(İletisimInfo);
        }

        // POST: Admin/İletisimInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var İletisimInfo = await _context.İletisimInfo.FindAsync(id);
            _context.İletisimInfo.Remove(İletisimInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool İletisimInfoExists(int id)
        {
            return _context.İletisimInfo.Any(e => e.Id == id);
        }
    }
}
