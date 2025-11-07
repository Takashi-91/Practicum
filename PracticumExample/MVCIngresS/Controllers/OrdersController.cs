using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MVCIngress.Models;
using MVCIngress.Services;

namespace MVCIngress.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IQueueSender _sender; private readonly IConfiguration _cfg;

        public OrdersController(IQueueSender sender, IConfiguration cfg)
        { _sender = sender; _cfg = cfg; }

        [HttpGet] public IActionResult Create() => View(new OrderInputViewModel());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderInputViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var json = JsonSerializer.Serialize(new { vm.OrderId, vm.UserId, vm.Amount, OccuredUtc = DateTime.UtcNow });
            var q = _cfg["Storage:QueueName"] ?? "orders-queue";
            await _sender.SendAsync(q, json);
            return RedirectToAction(nameof(Sent), new {id = vm.OrderId});
        }

        public IActionResult Sent(string id) { ViewBag.OrderId = id; return View(); }



        public IActionResult Index()
        {
            return View();
        }
    }
}
