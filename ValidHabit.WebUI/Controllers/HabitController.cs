using Microsoft.AspNetCore.Mvc;

namespace ValidHabit.WebUI.Controllers
{
    public class HabitController : BaseAuthorizeController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
