using FreeLancingWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreeLancingWebApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Chat()
        {
            // Get the current user
            var user = _userManager.GetUserAsync(User).Result;

            // Prepare the view model and return the chat interface view
            var model = new ChatViewModel
            {
                UserId = user.Id,
                UserName = user.UserName
            };

            return View(model);
        }
    }
}
