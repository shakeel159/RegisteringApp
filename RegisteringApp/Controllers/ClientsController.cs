using Microsoft.AspNetCore.Mvc;
using RegisteringApp.Models;

namespace RegisteringApp.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult AddClient()
        {
            var client = new Client()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Testing",
                Email = "Test@gmail.com"
            };
            return View(client);
        }

        public IActionResult Edit(int id)
        {
            return Content("id= " + id);
        }
    }
}
