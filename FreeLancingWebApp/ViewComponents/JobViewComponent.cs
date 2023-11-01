using FreeLancingWebApp;
using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.UI.ViewComponents
{
    public class JobViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public JobViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()

        {
            return View(_context.jobs.OrderBy(e=>e.CreationDate).Take(9));
        }
    }
}
