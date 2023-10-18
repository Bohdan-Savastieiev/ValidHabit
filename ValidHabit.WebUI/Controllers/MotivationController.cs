using Microsoft.AspNetCore.Mvc;
using ValidHabit.Application.Services;

namespace ValidHabit.WebUI.Controllers
{
    public class MotivationController : BaseAuthorizeController
    {
        private readonly IMotivationService _motivationService;

        public MotivationController(IMotivationService motivationService)
        {
            _motivationService = motivationService;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _motivationService.GetStandardMotivationQuestionsAsync();
            if (questions.IsSuccess)
            {
                return View(questions.Value);
            }

            return View("Error");
        }
    }
}
