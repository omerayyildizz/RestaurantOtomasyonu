using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOtomasyonu.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOtomasyonu.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var user = _db.ApplicationUser.ToList();
            var role = _db.Roles.ToList();
            var userrole = _db.UserRoles.ToList();
            foreach (var item in user)
            {
                var roleid = userrole.FirstOrDefault(x => x.UserId == item.Id).RoleId;
                item.Role = role.FirstOrDefault(u => u.Id == roleid).Name;
            }
            return View(user);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _db.ApplicationUser.FindAsync(id);
            _db.ApplicationUser.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
