using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350_Damien_.Models;

namespace MilestoneCST_350_Damien_.Controllers
{
    public class DifficultyController : Controller
    {
        /// <summary>
        /// Difficulty Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Send the selection of the board difficulty and board size to the minesweeper controller.
        /// </summary>
        /// <param name="customDifficulty"></param>
        /// <returns></returns>
        public IActionResult ProcessDifficultySelection(DifficultyModel customDifficulty)
        {

            return RedirectToAction("Index", "Minesweeper", customDifficulty);
        }

    }
}
