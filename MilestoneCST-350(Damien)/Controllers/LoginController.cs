using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Authenticate the users login info
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult ProcessLogin(UserModel user)
        {
            // Instantiate the SecurityServices class
            SecurityService securityService = new SecurityService();

            // Check if user is valid
            int userId = securityService.IsValid(user);

			// User the object to call the method IsValid
			if (userId != -1)
            {
                // Redirect to Difficulty controller and also send the current logged in user's id
                return RedirectToAction("Index", "Difficulty", new { userId = userId });
            }
            else
            {

                return View("LoginFailure", user);
            }
        }


    }
}
