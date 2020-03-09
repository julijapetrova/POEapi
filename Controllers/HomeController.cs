using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POEapi.Models;

namespace POEapi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly StashesContext _context;

        public HomeController(ILogger<HomeController> logger, StashesContext context)
        {
            _logger = logger; _context = context;
        }

        public IActionResult Index()
        {
            StashesController stashesController = new StashesController(_context);
            List<ItemDTO> items = (List<ItemDTO>)stashesController.GetAllItems().Result;
            return View(items);
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
