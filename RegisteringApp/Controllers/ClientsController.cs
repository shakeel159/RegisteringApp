using Microsoft.AspNetCore.Mvc;
using RegisteringApp.Data;
using RegisteringApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegisteringApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly RegistryContext _context;
        public ClientsController(RegistryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var client = await _context.Clients.Include(s => s._ID).ToListAsync();
            return View(client);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return View(Client);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
