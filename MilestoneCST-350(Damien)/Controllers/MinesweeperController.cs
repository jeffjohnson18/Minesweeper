using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class MinesweeperController : Controller
	{
		public int BoardSize = 8;
		//NOTE: There could be error here
		private double BoardDifficulty = 0.05;

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult DisplayMinesweeperGame()
		{
			GameBoardModel board = new GameBoardModel(BoardSize);

			board.SetUpBombs(BoardDifficulty);

			board.CalculateLiveNeighbors();

			return View("Minesweeper", board);
			//return minesweeper view
		}

	}
}

