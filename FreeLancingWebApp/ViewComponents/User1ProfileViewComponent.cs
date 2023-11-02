using FreeLancingWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.ViewComponents
{
    public class User1ProfileViewComponent : ViewComponent
    {
        private AppDbContext _context;

        public User1ProfileViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string uname)

        {

            var prof = _context.profileViewModels.Where(e => e.Name == uname);
            return View(prof);


            

        }
    }
}
