using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RegisteringApp.Models;
using RegisteringApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;


namespace RegisteringApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RegistryContext _context;
        public HomeController(ILogger<HomeController> logger, RegistryContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients.Include(c => c._ID).ToListAsync();
            return View(clients);
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
