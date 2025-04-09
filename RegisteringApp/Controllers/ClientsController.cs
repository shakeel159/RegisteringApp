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
        private readonly RegistryContext _db;
        public ClientsController(RegistryContext context, RegistryContext db)
        {
            _context = context;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //var client = await _context.LeadDetails.Include(s => s._ID).ToListAsync();
            IEnumerable<Client> LeadDetails = _db.LeadDetails.ToList();
            //return View(client);
            return View(LeadDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, FirstName, LastName, Email, PublicID, _ID")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.LeadDetails.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(client);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _context.LeadDetails.FirstOrDefaultAsync(x => x.Id == id);
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
            var Client = await _context.LeadDetails.FirstOrDefaultAsync(x => x.Id == id);
            return View(Client);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var client = await _context.LeadDetails.FindAsync(id);
            if (client != null)
            {
                _context.LeadDetails.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
