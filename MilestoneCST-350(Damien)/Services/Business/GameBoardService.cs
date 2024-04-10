using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MilestoneCST_350_Damien_.Models;
using System.Drawing;

namespace MilestoneCST_350_Damien_.Services.Business
{
    public class GameBoardService
    {
        /// <summary>
        /// Create Game Board by setting the grid up for the board and setting the size and difficulty
        /// </summary>
        /// <param name="customDifficulty"></param>
        /// <returns></returns>
        public GameBoardModel CreateGameBoard(DifficultyModel customDifficulty)
        {
            int BoardSize = customDifficulty.SizeOfBoard;
            GameBoardModel board = new GameBoardModel(BoardSize);
            board.Difficulty = customDifficulty.Difficulty;

            return board;
        }

        /// <summary>
        /// Initialize the game board by setting the bombs on the board and calculate the live nieghbors 
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public GameBoardModel InitializeGameBoard(GameBoardModel board)
        {
            GameBoardLogic logic = new GameBoardLogic(board);
            //set bombs up on board
            logic.SetUpBombs();

            // calculate live neighbors on board
            logic.CalculateLiveNeighbors();

            GameBoardModel newBoard = new GameBoardModel();

            newBoard.Size = logic.Size;
            newBoard.Grid = logic.Grid;
            newBoard.Difficulty = logic.Difficulty;

            return newBoard;
        }

        /// <summary>
        /// Recursively fill the board based on where the user clicked.
        /// </summary>
        /// <param name="clickedCell"></param>
        /// <param name="boardLogic"></param>
        public GameBoardModel RecursivelyFillBoard(string clickedCell, GameBoardModel originalBoard)
        {
            string[] parts = clickedCell.Split(',');

            int row = Int32.Parse(parts[0]);

            int col = Int32.Parse(parts[1]);

            GameBoardLogic boardLogic = new GameBoardLogic(originalBoard);

            //if cellFlagged do nothing, if not flagged recursivey fill board
            if (boardLogic.Grid[row, col].CellFlagged != true)
            {

                boardLogic.Grid[row, col].Visited = true;
                boardLogic.Fill(row, col);


                GameBoardModel newBoard = new GameBoardModel();

                newBoard.Size = boardLogic.Size;
                newBoard.Grid = boardLogic.Grid;
                newBoard.Difficulty = boardLogic.Difficulty;

                return newBoard;
            }
            else
            {
                return originalBoard;
            }
        }

        /// <summary>
        /// This marks a clicked cell as flagged.
        /// </summary>
        /// <param name="clickedCell"></param>
        /// <param name="board"></param>
        /// <returns></returns>
		public GameBoardModel PlaceFlag(string clickedCell, GameBoardModel board)
		{
			string[] parts = clickedCell.Split(',');

			int row = Int32.Parse(parts[0]);

			int col = Int32.Parse(parts[1]);

			GameBoardLogic boardLogic = new GameBoardLogic(board);

			GameBoardModel newBoard = new GameBoardModel();

            // Toggles and untoggles flag
			if(boardLogic.Grid[row, col].CellFlagged == true)
            {
                boardLogic.Grid[row, col].CellFlagged = false;
			}
            else
            {
				boardLogic.Grid[row, col].CellFlagged = true;
			}

            
            // return newBoard
			newBoard.Size = boardLogic.Size;
			newBoard.Grid = boardLogic.Grid;
			newBoard.Difficulty = boardLogic.Difficulty;

			return newBoard;

		}

		/// <summary>
		/// Gets the non bomb cells count
		/// </summary>
		/// <param name="board"></param>
		/// <returns></returns>
		public int GetNonBombCellsCount(GameBoardModel board)
        {
			GameBoardLogic boardLogic = new GameBoardLogic(board);

            return boardLogic.NonBombCells();
		}

        /// <summary>
        /// Check is all non bomb cells are revealed
        /// </summary>
        /// <param name="board"></param>
        /// <param name="nonBombCells"></param>
        /// <returns></returns>
        public bool IsAllNonBombCellsRevealedService(GameBoardModel board, int nonBombCells)
        {
			GameBoardLogic boardLogic = new GameBoardLogic(board);

			return boardLogic.IsAllNonBombCellsRevealed(nonBombCells);
		}
	}
}
