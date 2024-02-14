using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;

namespace MilestoneCST_350_Damien_.Controllers
{
	public class MinesweeperController : Controller
	{
		public static int BoardSize = 8;

		public static GameBoardModel board = new GameBoardModel(BoardSize);

		// You can only manually change the difficulty of the game as of right now
		private double BoardDifficulty = 0.06;

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			//set bombs up on board
            board.SetUpBombs(BoardDifficulty);

			// calcularte live neighbors on board
            board.CalculateLiveNeighbors();

			return View(board);
        }


		/// <summary>
		/// When a button is clicked mark it as visited and flood fill board
		/// </summary>
		/// <param name="clickedCell"></param>
		/// <returns>GameBoardModel</returns>
		public IActionResult HandleButtonClick(string clickedCell)
		{
			string[] parts = clickedCell.Split(',');

			int row = Int32.Parse(parts[0]);

			int col = Int32.Parse(parts[1]);

			board.Grid[row,col].Visited = true;

			board.Fill(row, col);


			return View("Index", board);
		}


	}
}

