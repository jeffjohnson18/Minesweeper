using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Process the users registration info by adding it to the SQL database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProcessRegistration(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (user == null)
            {
                return View("Failure");
            }
            else
            {
                securityService.RegisterUser(user);
                return RedirectToAction("RegistrationResult", new { success = true });
            }
        }

        /// <summary>
        /// Registration result
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public IActionResult RegistrationResult(bool success)
        {
            if (success)
            {
                return View("RegisterSuccess");
            }
            else
            {
                return View("RegisterFailure");
            }
        }
    }
}
