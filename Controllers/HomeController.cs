using CarRecommenderIA.Models;
using CarRecommenderIA.Services;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace CarRecommenderIA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MonsterAIService _monsterAIService;

        public HomeController(ILogger<HomeController> logger, MonsterAIService monsterAIService)
        {
            _logger = logger;
            _monsterAIService = monsterAIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetRecommendation(string userPrompt)
        {
            if (string.IsNullOrEmpty(userPrompt))
            {
                ViewData["Error"] = "Please enter a prompt.";
                return View("Index");
            }

            try
            {
                var recommendation = await _monsterAIService.GetCarRecommendations(userPrompt);
                ViewData["Recommendation"] = recommendation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching recommendations from MonsterAI.");
                ViewData["Error"] = "Failed to fetch recommendations. Please try again later.";
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
