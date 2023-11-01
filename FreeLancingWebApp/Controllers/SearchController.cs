using FreeLancingWebApp.Models;
using FreeLancingWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.Controllers
{
    public class SearchController : Controller
    {

        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult SearchIndex(string term,string selected)
        {
            if (selected == null)
            {
                var data = _context.jobs.Where(e => e.JobName.Contains(term) || e.JobDescription.Contains(term));



                return View(data);
            }
            else if (term==null) {
                var data = _context.jobs.Where(e => e.JobName == selected);




                return View(data);
            }
            else
            {
                var data = _context.jobs.Where(e => e.JobName.Contains(term) || e.JobDescription.Contains(term)&&e.JobName==selected);




                return View(data);
            }
        }
       
    }
}
