using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreeLancingWebApp.ViewComponents
{
    public class ProfilesViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public ProfilesViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public  IViewComponentResult Invoke()
        {
            var services = _context.profileViewModels.Take(5);
            return View(services);
        }
    }
}
