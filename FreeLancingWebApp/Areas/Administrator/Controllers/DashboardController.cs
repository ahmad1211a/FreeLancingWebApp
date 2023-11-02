using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]

    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.profileViewModels);
        }
        public IActionResult Jobs()
        {
            return View(_context.jobs);
        }
        public IActionResult Services()
        {
            return View(_context.services);
        }
    }
}
