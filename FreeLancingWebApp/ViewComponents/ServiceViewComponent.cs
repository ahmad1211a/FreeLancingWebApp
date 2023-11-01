using FreeLancingWebApp;
using FreeLancingWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FreeLancingWebApp.UI.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public ServiceViewComponent(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _context.services.ToListAsync();
            return View(services);
        }
    }
}
   