namespace MilestoneCST_350_Damien_.Models
{
	public class GameBoardModel
	{
		// Gameboard Properties
		public int Size { get; set; }
		public CellModel[,] Grid { get; set; }
		public double Difficulty { get; set; }


		/// <summary>
		/// Non-Default gameboard constructor
		/// Creates our gameboard with a new cell
		/// This gameboard will handle our game logic
		/// </summary>
		/// <param name="size"></param>
		public GameBoardModel(int size)
		{
			Size = size;

			Grid = new CellModel[Size, Size];

			for (int i = 0; i < Size; i++)
			{
				for (int k = 0; k < Size; k++)
				{
					Grid[i, k] = new CellModel();
				}
			}
		}



		/// <summary>
		/// This methods sets the bombs randomly on our board based on the difficulty
		/// </summary>
		/// <param name="difficulty"></param>
		public void SetUpBombs(double difficulty)
		{
			Random random = new Random();
			double randomNumber = 0;
			Difficulty = difficulty;
			for (int i = 0; i < Size; i++)
			{
				for (int k = 0; k < Size; k++)
				{
					randomNumber = random.NextDouble();


					if (randomNumber < difficulty)
					{
						Grid[i, k].LiveBomb = true;
					}
					else
					{
						Grid[i, k].LiveBomb = false;
					}
				}
			}
		}

		/// <summary>
		/// This method goes through each cell on the board and checks if there is a liveNeighbor 
		/// near them. If so the current cell increments it liveNeighbor count. 
		/// Checks a (3x3) area with the current cell in the middle.
		/// </summary>
		public void CalculateLiveNeighbors()
		{
			// for each row in the grid(board)
			for (int row = 0; row < Size; row++)
			{
				// for each column in the grid(board)
				for (int col = 0; col < Size; col++)
				{
					// set current cell 
					CellModel currentCell = Grid[row, col];
					
					// for each cell
					// check a 3x3 area with the current cell in the middle
					// if there is a live nieghbor.
					// also check if cell is on the board.
					if (IsValidCell(row + 1, col) == true)
					{
						if (Grid[row + 1, col].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}


					if (IsValidCell(row - 1, col) == true)
					{
						if (Grid[row - 1, col].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}


					if (IsValidCell(row, col + 1) == true)
					{
						if (Grid[row, col + 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}



					if (IsValidCell(row, col - 1) == true)
					{
						if (Grid[row, col - 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}

					if (IsValidCell(row + 1, col + 1) == true)
					{
						if (Grid[row + 1, col + 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}

					if (IsValidCell(row + 1, col - 1) == true)
					{
						if (Grid[row + 1, col - 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}

					if (IsValidCell(row - 1, col + 1) == true)
					{
						if (Grid[row - 1, col + 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}

					if (IsValidCell(row - 1, col - 1) == true)
					{
						if (Grid[row - 1, col - 1].LiveBomb == true)
						{
							currentCell.LiveNeighbors++;
						}
					}


				}
			}
		}

		/// <summary>
		/// Checks if a cell is on the grid(board)
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public bool IsValidCell(int row, int col)
		{

			if (row >= 0 && col >= 0 && row < Size && col < Size)
			{
				return true;

			}
			else
			{
				return false;

			}

		}

		/// <summary>
		/// counts all the cells on the board that is not a live bomb
		/// </summary>
		/// <returns></returns>
		public int nonBombCells()
		{
			// non-bomb variable
			int nonBombCount = 0;

			// for each cell on  the grid
			for (int i = 0; i < Size; i++)
			{
				for (int k = 0; k < Size; k++)
				{
					// if cell is not a live bomb incremente nonBombCount
					if (Grid[i, k].LiveBomb == false)
					{
						nonBombCount++;
					}
				}
			}
			return nonBombCount;
		}

		/// <summary>
		/// This method checks if the user has selected a live bomb
		/// </summary>
		/// <param name="selectedRow"></param>
		/// <param name="selectedCol"></param>
		/// <returns></returns>
		public bool IsCellBomb(int selectedRow, int selectedCol)
		{
			if (Grid[selectedRow, selectedCol].LiveBomb == true)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// This method checks if the user has revealed all non-bomb cells
		/// to win the game
		/// </summary>
		/// <param name="size"></param>
		/// <param name="bombCount"></param>
		/// <returns></returns>
		public bool IsAllNonBombCellsRevealed(int nonBombCellCount)
		{
			// area of grid minus the bomb count gives us the amount of cells that must be revealed to win
			int cellsReavealedToWin = nonBombCellCount;

			// variable for vistited cells on the board
			int visitedCells = 0;

			// for each cell on the board
			for (int i = 0; i < Size; i++)
			{
				for (int k = 0; k < Size; k++)
				{
					// check if the cell has been visited
					if (Grid[i, k].Visited == true)
					{
						// increment visitedCells varibale
						visitedCells++;
					}
				}
			}

			// after going through each cell on the board
			// check if the user has revealed all the non bomb cells
			if (visitedCells == cellsReavealedToWin)
			{
				return true;
			}
			return false;
		}


		/// <summary>
		/// Method that runs our flood fill recursion
		/// </summary>
		/// <param name="startRow"></param>
		/// <param name="startCol"></param>
		public void Fill(int startRow, int startCol)
		{
			// if the starting cell has live neighbors don't flood fill
			if (Grid[startRow, startCol].LiveNeighbors > 0)
			{
				return;
			}
			// However if cell has no live neighbors call the flood fill recursion method
			else
			{
				FloodFill(startRow, startCol);
			}
		}

		/// <summary>
		/// This method uses a recursive definition that reveals a chunks of cells with no live neighbors.
		/// </summary>
		/// <param name="startRow"></param>
		/// <param name="startCol"></param>
		public void FloodFill(int startRow, int startCol)
		{
			// check if out of bounds. Stop
			if (startRow < 0 || startRow > Size - 1 || startCol < 0 || startCol > Size - 1)
			{
				return;
			}

			// check if has live neighbors. Stop
			if (Grid[startRow, startCol].LiveNeighbors > 0)
			{
				// reveal cell that has live neighbors
				Grid[startRow, startCol].Visited = true;

				return;
			}

			// move north, east, south, west recursively

			// vist current cell
			Grid[startRow, startCol].Visited = true;


			if (IsValidCell(startRow - 1, startCol) == true && !Grid[startRow - 1, startCol].Visited)
			{
				// Move North (up)
				FloodFill(startRow - 1, startCol);

			}

			if (IsValidCell(startRow, startCol + 1) == true && !Grid[startRow, startCol + 1].Visited)
			{
				// Move East (right)
				FloodFill(startRow, startCol + 1);
			}


			if (IsValidCell(startRow + 1, startCol) == true && !Grid[startRow + 1, startCol].Visited)
			{
				// Move South (Down)
				FloodFill(startRow + 1, startCol);
			}


			if (IsValidCell(startRow, startCol - 1) == true && !Grid[startRow, startCol - 1].Visited)
			{
				// Move West (left)
				FloodFill(startRow, startCol - 1);
			}


		}
	}
}
