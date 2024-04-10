using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using Org.BouncyCastle.Bcpg;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class SavedGameController : Controller
	{
		// Class Level Variables
		private SavedGameService savedGameService = new SavedGameService();
		private static List<SavedGameModel> savedGamesList;
		private static int userId;

		/// <summary>
		/// Display all of the saved games for the current user.
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
            // Get the current UserId from the Minesweeper controller (Method: ProcessDisplaySavedGames())
            userId = (int)TempData["UserId"];

			// Get all of the current users saved games
			savedGamesList = savedGameService.GetAllGames(userId);

			// Display all of the saved games for that user
			return View(savedGamesList);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IActionResult SaveAGame()
		{
            // Get the saved game from the Minesweeper controller (Method: ProcessSaveAGame())
            string savedGameJson = TempData["SavedGameJson"] as string;
			SavedGameModel savedGame = JsonConvert.DeserializeObject<SavedGameModel>(savedGameJson);

			// save the game to the SQL database
			savedGameService.SaveOneGame(savedGame);

			// Redirect back to the home page
			return RedirectToAction("Index", "Home");

		}

		/// <summary>
		/// Delete a saved game
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
        public ActionResult DeleteSavedGame(int Id)
        {
			// Delete a selected saved game
			savedGameService.DeleteOneGame(Id);

			// Get the updated list of games and display it
            return View("Index", savedGameService.GetAllGames(userId));
        }

		/// <summary>
		/// Resume a previous game that was saved
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
        public ActionResult ResumeSavedGame(int Id)
        {
			// get the saved game the user wants to resume
            GameBoardModel resumeBoard = savedGameService.GetOneGame(Id);

			// Send the game the user wants to resume back to the minesweeper controller
			// The minesweeper controller will handle resuming a saved game
            string serializedBoard = JsonConvert.SerializeObject(resumeBoard);
            TempData["ResumeGame"] = serializedBoard;

			// Redirect back to the Minesweeper controller
            return RedirectToAction("Index", "Minesweeper");

        }

    }
}
