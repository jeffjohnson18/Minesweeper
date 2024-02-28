using MilestoneCST_350_Damien_.Models;

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
        public GameBoardLogic InitializeGameBoard(GameBoardModel board)
        {
            GameBoardLogic initializedBoard = new GameBoardLogic(board);
            //set bombs up on board
            initializedBoard.SetUpBombs();

            // calcularte live neighbors on board
            initializedBoard.CalculateLiveNeighbors();

            return initializedBoard;
        }

        /// <summary>
        /// Revursively fill the board based on where the user clicked.
        /// </summary>
        /// <param name="clickedCell"></param>
        /// <param name="boardLogic"></param>
        public void recursivelyFillBoard(string clickedCell, GameBoardLogic boardLogic)
        {
            string[] parts = clickedCell.Split(',');

            int row = Int32.Parse(parts[0]);

            int col = Int32.Parse(parts[1]);

            boardLogic.Grid[row, col].Visited = true;

            boardLogic.Fill(row, col);

        }
    }
}
