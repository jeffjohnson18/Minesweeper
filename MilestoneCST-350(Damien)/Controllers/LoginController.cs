using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services;

namespace MilestoneCST_350_Damien_.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            // Instantiate the SecurityServices class
            SecurityService securityService = new SecurityService();

            // User the object to call the method IsValid
            if (securityService.IsValid(user) == true)
            {

                // NOTE: Create view to minesweeper game page instead of Login Success
                // Minesweeper Controller will take care of displaying the minesweeper game.
                return RedirectToAction("Index", "Minesweeper");
            }
            else
            {

                return View("LoginFailure", user);
            }
        }


    }
}
