using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpContextAccessor _context;
		/// <summary>
		/// Login Page
		/// </summary>
		/// <returns></returns>
		/// 
		public IActionResult Index()
		{
			return View();
		}

		// Constructor to inject dependency variable (context)
		public LoginController(IHttpContextAccessor context)
		{
			_context = context;
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
				// verify the state 
				_context.HttpContext.Session.SetString("UserName", user.UserName);

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
