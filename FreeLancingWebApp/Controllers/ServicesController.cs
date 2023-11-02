using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreeLancingWebApp;
using FreeLancingWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace FreeLancingWebApp.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.services != null ? 
                          View(await _context.services.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.services'  is null.");
        }
        public IActionResult Contact()
        {
            return View();  
        }
        [AllowAnonymous]
        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var service = await _context.services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(Service service)
        {
            if (ModelState.IsValid)
            {
                if (service.ImageFile != null)
                {
                    // Handle image upload
                    var fileName = Path.GetFileName(service.ImageFile.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await service.ImageFile.CopyToAsync(stream);
                    }

                    service.ServiceImgUrl = fileName; // Store the file name in the database
                }

                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var service = await _context.services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingService = _context.services.Find(id);

                if (existingService == null)
                {
                    return NotFound();
                }
                if (service.ImageFile != null)
                {
                    // Handle image upload and update ServiceImgUrl
                    var fileName = Path.GetFileName(service.ImageFile.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        service.ImageFile.CopyTo(stream);
                    }

                    existingService.ServiceImgUrl = fileName;
                }

                try
                {
                    _context.Update(existingService); // Update the existing service, not 'service'
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }


        // GET: Services/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var service = await _context.services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.services == null)
            {
                return Problem("Entity set 'AppDbContext.services'  is null.");
            }
            var service = await _context.services.FindAsync(id);
            if (service != null)
            {
                _context.services.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.services?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
