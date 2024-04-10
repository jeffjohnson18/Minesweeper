namespace MilestoneCST_350_Damien_.Models
{
	public class SavedGameModel
	{
		// SavedGameModel Properties
		public int Id { get; set; }

		public int UserId { get; set; }
		public string TimeSaved { get; set; }
		public GameBoardModel? GameBoard { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public SavedGameModel()
		{
			Id = 0;
			UserId = 0;
			TimeSaved = "";
			GameBoard = null;
		}

		/// <summary>
		/// Non default constructor
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userId"></param>
		/// <param name="timeSaved"></param>
		/// <param name="gameBoard"></param>
		public SavedGameModel(int id, int userId, string timeSaved, GameBoardModel gameBoard)
		{
			Id = id;
			UserId = userId;
			TimeSaved = timeSaved;
			GameBoard = gameBoard;
		}
	}
}
