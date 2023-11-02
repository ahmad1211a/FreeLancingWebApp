using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.ViewComponents
{
    public class ProfileJobsViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public ProfileJobsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string uname)

        {
            return View(_context.jobs.Where(e=>e.UName==uname));
        }
    }
}
