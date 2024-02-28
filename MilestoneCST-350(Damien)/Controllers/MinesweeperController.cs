using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class MinesweeperController : Controller
	{
		public static GameBoardLogic? boardLogic = new GameBoardLogic();

        public GameBoardService boardService = new GameBoardService();


        /// <summary>
        /// Minesweeper game board page
		/// Create Gameboard using the users selected board size and difficulty
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(DifficultyModel customDifficulty)
		{
			GameBoardModel board = boardService.CreateGameBoard(customDifficulty);

			boardLogic = boardService.InitializeGameBoard(board);

            return View(boardLogic);
		}


		/// <summary>
		/// When a button is clicked mark it as visited and flood fill board
		/// </summary>
		/// <param name="clickedCell"></param>
		/// <returns>GameBoardModel</returns>
		public IActionResult HandleButtonClick(string clickedCell)
		{
			boardService.recursivelyFillBoard(clickedCell, boardLogic);

            return View("Index", boardLogic);
		}


	}
}

