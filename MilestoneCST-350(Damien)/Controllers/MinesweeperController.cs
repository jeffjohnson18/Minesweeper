using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;
using Newtonsoft.Json;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class MinesweeperController : Controller
	{
		// Class level Variables
		public static GameBoardModel? board;
		public GameBoardService boardService = new GameBoardService();
		private static int currentUserId = 0;
		private readonly IHttpContextAccessor _context;

	
		public MinesweeperController(IHttpContextAccessor context)
		{
			_context = context;
		}


		/// <summary>
		/// Minesweeper game board page
		/// Create Gameboard using the users selected board size and difficulty.
		/// The user can also resume a previous game they saved.
		/// </summary>
		/// <returns></returns>
		public IActionResult Index(DifficultyModel customDifficulty)
		{
			// gather the current userid from session variable
			int? stateUserId = _context.HttpContext.Session.GetInt32("UserId");

			// check if state is empty
			// if null or less than or equal to 0, return to home page
			// if valid, pass test and redirect to minesweeper page
			if (stateUserId <= 0 || stateUserId == null)
			{
				// redirect to home page
				return RedirectToAction("Index", "Login");
			}


			// If the user isn't trying to resume a game
			if (TempData["ResumeGame"] == null)
			{
				// Create and initialize the users custom minesweeper game board
				board = boardService.CreateGameBoard(customDifficulty);
				board = boardService.InitializeGameBoard(board);

				//set class variable current userId to the difficuty models user id property
				currentUserId = customDifficulty.UserId;

				// Return the initalized board to the index view
				// This display the custom made board
				return View(board);
			}
			// If the user is trying to resume a previous game they saved
			else
			{
				// Clear any previous boards just in case
				board = null;

				// Get the game the user wants to resume
				string resumeGameJsonString = TempData["ResumeGame"] as string;
				GameBoardModel resumeGame = JsonConvert.DeserializeObject<GameBoardModel>(resumeGameJsonString);


				// Set class level board to the game the user wants to resume and display it
				board = resumeGame;
				return View(board);
			}
		}



		/// <summary>
		/// When a button is left clicked mark it as visited and flood fill board
		/// </summary>
		/// <param name="clickedCell"></param>
		/// <returns>GameBoardModel</returns>
		public IActionResult LoadUpdatedBoard_WhenLeftClick(string clickedCell)
		{
			// recursively fill board based on where the user just left clicked on the board.
			board = boardService.RecursivelyFillBoard(clickedCell, board);

			// update only the gameboard section of the index page.
			return PartialView("GameBoard", board);

		}

		/// <summary>
		/// When a button is right clicked mark the cell as flagged to place a flag on the board
		/// </summary>
		/// <param name="clickedCell"></param>
		/// <returns></returns>
		public IActionResult LoadUpdatedBoard_WhenRightClick(string clickedCell)
		{
			// place a flag where the user right clicked on the board.
			board = boardService.PlaceFlag(clickedCell, board);

			// update only the gameboard section of the index page.
			return PartialView("GameBoard", board);

		}

		/// <summary>
		/// Redirect to the saved game controller to handle displaying saved games
		/// for the current user.
		/// </summary>
		/// <returns></returns>
		public IActionResult ProcessDisplaySavedGames()
		{
			// Send the current userId to the SavedGame controller.
			// This will help our database know who exactly wants to see their saved games
			TempData["UserId"] = currentUserId;

			// Redirect to Saved game Controller to display all of the current user's saved games.
			return RedirectToAction("Index", "SavedGame");
		}

		/// <summary>
		/// Redirect to the saved game controller to handle saving a game
		/// for the current user
		/// </summary>
		/// <returns></returns>
		public IActionResult ProcessSaveAGame()
		{
			// Get the time the user saved the game
			string timeSaved = DateTime.Now.ToString();

			// Get the current game state of the board
			GameBoardModel savedBoard = board;

			// Create and itialize a SavedGameModel with the current user id, the time the game was saved
			// and the current game state of the board they want to save.
			SavedGameModel savedGame = new SavedGameModel(0, currentUserId, timeSaved, savedBoard);

			// Send the SavedGameModel created above to the SavedGameController where it will 
			// handle the process of saving a game.
			string savedGameJson = JsonConvert.SerializeObject(savedGame);
			TempData["SavedGameJson"] = savedGameJson;

			// redirect to the SavedGameController
			return RedirectToAction("SaveAGame", "SavedGame");
		}

	}
}

