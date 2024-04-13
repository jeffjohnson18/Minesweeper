using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class DifficultyController : Controller
	{
		// Class level
		private readonly IHttpContextAccessor _context;
		private static int currentUserId = 0;

		public DifficultyController(IHttpContextAccessor context)
		{
			_context = context;
		}

		/// <summary>
		/// Difficulty Page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index(int userId)
		{
			// gather the current userid from session variable
			int? stateUserId = _context.HttpContext.Session.GetInt32("UserId");

			// check if state is empty
			// if empty, return to login page
			// if valid, allow the user to create a minesweeper board
			if (stateUserId <= 0 || stateUserId == null)
			{
				// redirect to home page
				return RedirectToAction("Index", "Login");
			}

			// set current user id 
			currentUserId = userId;
			return View();
		}

		/// <summary>
		/// Send the selection of the board difficulty and board size to the minesweeper controller.
		/// </summary>
		/// <param name="customDifficulty"></param>
		/// <returns></returns>
		public IActionResult ProcessDifficultySelection(DifficultyModel customDifficulty)
		{

			// Set custom DifficultyModel UserId property to current user.
			// This is used to distinguish which user is playing 
			customDifficulty.UserId = currentUserId;

			// Redirect to Minesweeper controller and send the customDifficulty the user just created.
			return RedirectToAction("Index", "Minesweeper", customDifficulty);
		}

	}
}
