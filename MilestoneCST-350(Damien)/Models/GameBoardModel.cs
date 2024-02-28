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

					Grid[i, k].RowNumber = i;
					Grid[i, k].ColNumber = k;


				}
			}
		}
    }
}
