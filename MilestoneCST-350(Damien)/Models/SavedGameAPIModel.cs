namespace MilestoneCST_350_Damien_.Models
{
	public class SavedGameAPIModel
	{
		// Parameterless constructor
		public SavedGameAPIModel()
		{
		}

		// Parameterized Constructor
		public SavedGameAPIModel(int gameId, int userId, string timeSaved, string game)
		{
			GameId = gameId;
			UserId = userId;
			TimeSaved = timeSaved;
			Game = game;
		}

		public int GameId { get; set; }
		public int UserId { get; set; }
		public string TimeSaved { get; set; }
		public string Game { get; set; }
	}
}
