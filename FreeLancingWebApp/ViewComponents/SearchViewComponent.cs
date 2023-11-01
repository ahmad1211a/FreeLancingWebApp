using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeLancingWebApp;
using FreeLancingWebApp.Models.ViewModels;


namespace FreeLancingWebApp.UI.ViewComponents

{
    [ViewComponent]
    public class SearchViewComponent : ViewComponent
    {
        private AppDbContext _context;

        public SearchViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()

        {
            SearchViewModel model = new SearchViewModel()
            {
                jobs=_context.jobs.ToList(),
                services=_context.services.ToList(),
            };

        //     List<SearchViewModel> model = new List<SearchViewModel>
             //{
    // new SearchViewModel
    //{
      //  services = await _context.services.ToListAsync(),
        //jobs = await _context.jobs.ToListAsync()
   // }
     //    };
     
            return View(model);

        }

    }
}
