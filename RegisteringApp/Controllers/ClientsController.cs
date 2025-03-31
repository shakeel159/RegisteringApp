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
            var client = await _context.Clients.ToListAsync();
            return View(client);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
