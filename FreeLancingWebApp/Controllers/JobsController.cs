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
using FreeLancingWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FreeLancingWebApp.Controllers
{
    [Authorize]

    public class JobsController : Controller
    {
        #region Configration
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;


        #endregion

        private readonly AppDbContext _context;

        public JobsController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]

        public IActionResult Profile(string email)

        {
            
            var prof=_context.profileViewModels.Where(e=>e.Email==email);
            return View(prof);
        }
     
        public IActionResult UserProfile(string uname)

        {
          
            var prof = _context.profileViewModels.Where(e => e.Name == uname);
            return View(prof);
        }
        public IActionResult CreateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProfile(profileViewModels profile)
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            
            var data = _context.jobs;
         
                     return View(data); 
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> IndexSelected(string ServiceName)
        {
            var data = _context.jobs.Where(e => e.JobName == ServiceName);
            
            return View(data);
        }

        [AllowAnonymous]

        public IActionResult Details(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job =  _context.jobs
                .Where(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(_context.services, "ServiceId", "Category");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(Job job)
        {


            if (ModelState.IsValid)
            {
               var user = await _userManager.GetUserAsync(User);
                if (job.ImageFile != null)
                {
                    // Handle image upload
                    var fileName = Path.GetFileName(job.ImageFile.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await job.ImageFile.CopyToAsync(stream);
                    }

                    job.Img = fileName; // Store the file name in the database
                }

                //job.CreationDate = DateTime.Now;
                job.UEmail = user.UserName;
                job.UName = user.Email;
                var selectedCategory = job.ServiceId;   

                
                var cet = _context.services.ToList();
                var cot=cet.FirstOrDefault(e=>e.ServiceId== selectedCategory);
                job.JobName = cot.Category;
                var gn = cot;

                
               // var cat = _context.services.Where(s => s.ServiceId == job.ServiceId);
              
                //job.JobName = _context.services; 
                
                    // Rest of your action code
                
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingService = _context.jobs.Find(id);

                if (existingService == null)
                {
                    return NotFound();
                }


                // Handle image upload and update ServiceImgUrl
                var fileName = Path.GetFileName(job.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    job.ImageFile.CopyTo(stream);
                }

                existingService.Img = fileName;
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            return View(job);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> EditProfile(int? id)
        {
            if (id == null || _context.profileViewModels == null)
            {
                return NotFound();
            }

            var profile = await _context.profileViewModels.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> EditProfile(int id, profileViewModels profile)
        {

            if (ModelState.IsValid)
            {
                var existingService = _context.profileViewModels.Find(id);

                if (existingService == null)
                {
                    return NotFound();
                }

               
                    // Handle image upload and update ServiceImgUrl
                    var fileName = Path.GetFileName(profile.ImageFile.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        profile.ImageFile.CopyTo(stream);
                    }

                    existingService.Img = fileName;
                

                // Update the properties of the existing profile with the values from the request
                existingService.SelfDescription = profile.SelfDescription;
                existingService.Remotly = profile.Remotly;
                existingService.Location = profile.Location;
                existingService.Name = profile.Name;
                existingService.Expertise = profile.Expertise;

                _context.Update(existingService);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(profile);

        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.jobs == null)
            {
                return Problem("Entity set 'AppDbContext.jobs'  is null.");
            }
            var job = await _context.jobs.FindAsync(id);
            if (job != null)
            {
                _context.jobs.Remove(job);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       

        private bool JobExists(int id)
        {
          return (_context.jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}
