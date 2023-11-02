using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FreeLancingWebApp.Models;
using FreeLancingWebApp.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FreeLancingWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        /*Register   var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
        
          await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Chat"); 
        foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
         */
        #region Configration
        private readonly ILogger<HomeController> _logger;

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly AppDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {

            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Users
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
          IdentityResult Iresult = null;


            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = _context.Users.Any(x => x.Email == model.Email);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError("Email", "User with this email already exists");
                    return View(model);
                }

                var isUnameAlreadyExists = _context.Users.Any(x => x.UserName == model.Name);
                if (isUnameAlreadyExists)
                {
                    ModelState.AddModelError("Name", "User with this user name already exists");
                    return View(model);
                }
                if (model.ImageFile != null)
                {
                    // Handle image upload
                    var fileName = Path.GetFileName(model.ImageFile.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    model.Img = fileName; // Store the file name in the database
                }
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Name,

                };

                var role = await _roleManager.FindByIdAsync(user.Id);

                var Profile = new profileViewModels
                {
                    Profileid = model.ID,
                    Email = model.Email,
                    Name = model.Name,
                    Location = model.Location,
                    SelfDescription = model.SelfDescription,
                    Remotly = model.Remotly,
                    Img = model.Img,
                    Expertise = model.Expertise
                };





                var appuser = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                Iresult = await _userManager.AddToRoleAsync(user, "User");


                if (result.Succeeded)

                {



                    _context.profileViewModels.Add(Profile);

                    _context.RegisterViewModel.Add(model);
                    _context.SaveChanges();


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // return RedirectToAction("Chat");
                    return RedirectToAction("Login", "Account");

                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
              

                var result = await _signInManager.PasswordSignInAsync(
                    model.Email!,
                    model.Password,
                    model.RememberMe,
                    false);
            
                if (result.Succeeded)
                {
                    ViewBag.UEmail = model.Email;
                    var user = await _userManager.FindByEmailAsync(model.Email!);
                    var userEmail = user.Email;
                    HttpContext.Session.SetString("UserEmail", user.Email);


                    if (await _userManager.IsInRoleAsync(user!, "Administrator"))
                   {
                      return RedirectToAction("Index", "Dashboard", new { area = "Administrator", email = userEmail });
                    }
                    if (await _userManager.IsInRoleAsync(user!, "User"))
                    {
                        return RedirectToAction("UserProfile", "Jobs", new { email = userEmail });
                    }


                }
                ModelState.AddModelError("", "Invalid User or Password");
                return View(model);

                
            }
            return View(model);


        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        #endregion

        #region Roles
       // [Authorize(Roles = "Administrators")]

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
      //  [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.Rolename

                };  
                var result =await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                ModelState.AddModelError("", "Not Created");
                return View(model);

            }
            return View(model);
        }

        [HttpGet]
      //  [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> EditRole(string id)
        {
            var role =await _roleManager.FindByIdAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            EditRoleViewModel model = new EditRoleViewModel
            { 
                RoleId = role.Id,
                RoleName = role.Name
            };

            foreach(var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user,role.Name!))
                {
                    model.Users.Add(user.Email!);
                }
            }

            return View(model);
        }
        [HttpPost]
       // [Authorize(Roles = "Administrators")]


        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role=await _roleManager.FindByIdAsync(model.RoleId!);
                role.Name = model.RoleName;
               var result= await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return RedirectToAction("RoleList");
        }

        [HttpGet]
      //  [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> DeleteRole(string id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id); 
            return View(role);
        }

        [HttpPost]
      //  [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> DeleteRole(string id,IdentityRole r)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            var res=await _roleManager.DeleteAsync(role);   
            if(res.Succeeded)
            {
                return RedirectToAction(nameof(RoleList));
            }
            return View(role);
        }
        [HttpGet]
        // [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> UserRole(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            List<UserRoleViewModel> userRoleViewModels = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users)
            {
                UserRoleViewModel model = new UserRoleViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id
                };
                if (await _userManager.IsInRoleAsync(user, role.Name!))
                {

                    model.IsSelected = true;

                }
                else
                {
                    model.IsSelected = false;


                }


                userRoleViewModels.Add(model);
            }

                return View(userRoleViewModels);
            
        }


       
       


        [HttpPost]
      //  [Authorize(Roles = "Administrators")]

        public async Task<IActionResult> UserRole(string id, List<UserRoleViewModel> models)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            IdentityResult result = null;


            for (int i = 0; i < models.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(models[i].UserId);

                if (models[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!models[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }

               
               
            }
            if (result!.Succeeded)
            {
                return RedirectToAction("EditRole", new { id = id });
            }



            return View(models);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

       
    }
}


