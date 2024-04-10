using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Data;

namespace MilestoneCST_350_Damien_.Services.DataAccess
{
	public class SavedGameDAO
	{
		// class level
		private SavedGameData savedGameData = new SavedGameData();

		/// <summary>
		/// Saves a game to the SQL datbase
		/// </summary>
		/// <param name="savedGame"></param>
		/// <returns></returns>
		public bool SaveOneGame(SavedGameModel savedGame)
		{
			return savedGameData.SaveOneGame(savedGame);
		}

		/// <summary>
		/// Gets all of the saved games for that certain user from the SQL database
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<SavedGameModel> GetAllGames(int userId)
		{
			return savedGameData.GetAllGames(userId);

		}

		/// <summary>
		/// Deletes a saved game from th SQL database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int DeleteOneGame(int id)
		{
			return savedGameData.DeleteOneGame(id);
		}

		/// <summary>
		/// Gets a saved game from SQL Database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public GameBoardModel GetOneGame(int id)
		{
            return savedGameData.GetOneGame(id);

        }
    }
}
