using Microsoft.AspNetCore.Mvc;
using ValidHabit.Application.Services;
using ValidHabit.Application.Utilities;
using ValidHabit.WebUI.Models;

namespace ValidHabit.WebUI.Controllers
{
    public class DashboardController : BaseAuthorizeController
    {
        private readonly IMotivationService _motivationService;
        private readonly IHabitTrackerService _habitTrackerService;

        public DashboardController(IMotivationService motivationService,
            IHabitTrackerService habitTrackerService)
        {
            _motivationService = motivationService;
            _habitTrackerService = habitTrackerService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hasAnsweredResult = await _motivationService.HasAnsweredMotivationQuestions(UserId);
            if (!hasAnsweredResult.IsSuccess)
            {
                var errorModel = new ErrorViewModel { ErrorMessage = hasAnsweredResult.ErrorMessage };
                return View("Error", errorModel);
            }

            if (!hasAnsweredResult.Value)
            {
                RedirectToAction("Index", "Motivation");
            }

            return View();
        }
    }
}
