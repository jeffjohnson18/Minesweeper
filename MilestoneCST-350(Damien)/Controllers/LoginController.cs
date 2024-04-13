using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class LoginController : Controller
	{
		// Use dependecy injection
		// IHttpContextAccessor interface allows us to access the session
		// Create an object named "_context"
		// prefix convention "_" denotes private fields with a class
		private readonly IHttpContextAccessor _context;


		/// <summary>
		/// Constructor of the Login Controller
		/// </summary>
		/// <param name="context"></param>
		public LoginController(IHttpContextAccessor context)
		{
			_context = context;
		}

		/// <summary>
		/// Login Page
		/// </summary>
		/// <returns></returns>
		/// 
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
				// Define the key value pair to store in the
				// session object
				_context.HttpContext.Session.SetInt32("UserId", userId);

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
