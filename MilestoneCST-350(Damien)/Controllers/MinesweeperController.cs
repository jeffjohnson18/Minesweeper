using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class MinesweeperController : Controller
	{
		// Class level Variables
        public static GameBoardModel? board;
        public GameBoardService boardService = new GameBoardService();


        /// <summary>
        /// Minesweeper game board page
		/// Create Gameboard using the users selected board size and difficulty
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(DifficultyModel customDifficulty)
		{
			board = boardService.CreateGameBoard(customDifficulty);

			board = boardService.InitializeGameBoard(board);

            return View(board);
		}


		/// <summary>
		/// When a button is clicked mark it as visited and flood fill board
		/// </summary>
		/// <param name="clickedCell"></param>
		/// <returns>GameBoardModel</returns>
		public IActionResult HandleButtonClick(string clickedCell)
		{
			board = boardService.recursivelyFillBoard(clickedCell, board);

            return View("Index", board);
		}


	}
}

