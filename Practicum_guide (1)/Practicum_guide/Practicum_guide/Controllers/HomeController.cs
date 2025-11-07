using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practicum_guide.Data;
using Practicum_guide.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Practicum_guide.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private const string QueueName = "events-queue";

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalEvents = await _context.Events.CountAsync();
            var lastest = await _context.Events.OrderByDescending(e=>e.Id).Take(50).ToListAsync();
            return View(lastest);
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
