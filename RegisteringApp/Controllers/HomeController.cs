using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisteringApp.Data;
using RegisteringApp.Models;

namespace RegisteringApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RegistryContext _db;

        private readonly RegistryContext _context;
        public HomeController(ILogger<HomeController> logger, RegistryContext context, RegistryContext db)
        {
            _logger = logger;
            _context = context;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            //var clients = await _context.LeadDetails.Include(c => c._ID).ToListAsync();
            IEnumerable<Client> LeadDetails = _db.LeadDetails.ToList();
            //return View(clients);
            return View(LeadDetails);
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
