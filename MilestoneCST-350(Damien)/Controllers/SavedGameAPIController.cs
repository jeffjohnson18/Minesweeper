using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Business;

namespace MilestoneCST_350_Damien_.Controllers
{
	[ApiController]
	public class SavedGameAPIController : ControllerBase
	{
		// Import list and service class
		// private static List<SavedGameModel> savedGamesList;
		private SavedGameService savedGameService = new SavedGameService();

		[Route("api/showAllGames")]
		public ActionResult<IEnumerable<SavedGameAPIModel>> Index()
		{
			List<SavedGameAPIModel> savedGamesList = savedGameService.GetAllGamesAPI();
			return savedGamesList;
		}

		[HttpDelete("api/deleteOneGame/{id}")]
		public ActionResult<IEnumerable<SavedGameAPIModel>> Delete(int id)
		{
			List<SavedGameAPIModel> savedGamesList = savedGameService.GetAllGamesAPI();
			int rowsAffected = savedGameService.DeleteGameByGameIDAPI(id);

			return savedGamesList;
		}

		[HttpGet("api/showSavedGames/{id}")]
		public ActionResult<IEnumerable<SavedGameAPIModel>> Get(int id)
		{
			List<SavedGameAPIModel> savedGamesList = savedGameService.GetGameByIDAPI(id);
			return savedGamesList;
		}

	}
}
