﻿using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.DataAccess;

namespace MilestoneCST_350_Damien_.Services.Business
{
	public class SavedGameService
	{
		// class level
		private SavedGameDAO savedGameDAO = new SavedGameDAO();

		/// <summary>
		/// Saves a game to the SQL datbase
		/// </summary>
		/// <param name="savedGame"></param>
		/// <returns></returns>
		public bool SaveOneGame(SavedGameModel savedGame)
		{
			return savedGameDAO.SaveOneGame(savedGame);
		}

		/// <summary>
		/// Gets all of the saved games for that certain user from the SQL database
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<SavedGameModel> GetAllGames(int userId)
		{
			return savedGameDAO.GetAllGames(userId);

		}

		/// <summary>
		/// Deletes a saved game from th SQL database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int DeleteOneGame(int id)
		{
			return savedGameDAO.DeleteOneGame(id);
		}

		/// <summary>
		/// Gets a saved game from SQL Database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public GameBoardModel GetOneGame(int id)
		{
			return savedGameDAO.GetOneGame(id);
		}

		/// <summary>
		/// Get all games from savedgames, regardless of userid
		/// </summary>
		/// <returns></returns>
		public List<SavedGameAPIModel> GetAllGamesAPI()
		{
			return savedGameDAO.GetAllGamesAPI();
		}

		/// <summary>
		/// Deletes a saved game from db by game id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int DeleteGameByGameIDAPI(int id)
		{
			return savedGameDAO.DeleteGameByGameIDAPI(id);
		}

		/// Deletes a saved game from db by game id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<SavedGameAPIModel> GetGameByIDAPI(int id)
		{
			return savedGameDAO.GetGameByIDAPI(id);
		}
	}
}
